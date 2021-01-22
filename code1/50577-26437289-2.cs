    /// <summary>
	/// Thread safe event invoker
	/// </summary>
	public sealed class ThreadSafeEventInvoker
	{
		/// <summary>
		/// Dictionary of delegates
		/// </summary>
		readonly ConcurrentDictionary<Delegate, DelegateHolder> delegates = new ConcurrentDictionary<Delegate, DelegateHolder>();
		/// <summary>
		/// List of delegates to be called, we need it because it is relatevely easy to implement a loop with list
		/// modification inside of it
		/// </summary>
		readonly LinkedList<DelegateHolder> delegatesList = new LinkedList<DelegateHolder>();
		/// <summary>
		/// locker for delegates list
		/// </summary>
		private readonly ReaderWriterLockSlim listLocker = new ReaderWriterLockSlim();
		/// <summary>
		/// Add delegate to list
		/// </summary>
		/// <param name="value"></param>
		public void Add(Delegate value)
		{
			var holder = new DelegateHolder(value);
			if (!delegates.TryAdd(value, holder)) return;
			listLocker.EnterWriteLock();
			delegatesList.AddLast(holder);
			listLocker.ExitWriteLock();
		}
		/// <summary>
		/// Remove delegate from list
		/// </summary>
		/// <param name="value"></param>
		public void Remove(Delegate value)
		{
			DelegateHolder holder;
			if (!delegates.TryRemove(value, out holder)) return;
			Monitor.Enter(holder);
			holder.IsDeleted = true;
			Monitor.Exit(holder);
		}
		/// <summary>
		/// Raise an event
		/// </summary>
		/// <param name="args"></param>
		public void Raise(params object[] args)
		{
			DelegateHolder holder = null;
			try
			{
				// get root element
				listLocker.EnterReadLock();
				var cursor = delegatesList.First;
				listLocker.ExitReadLock();
				while (cursor != null)
				{
					// get its value and a next node
					listLocker.EnterReadLock();
					holder = cursor.Value;
					var next = cursor.Next;
					listLocker.ExitReadLock();
					// lock holder and invoke if it is not removed
					Monitor.Enter(holder);
					if (!holder.IsDeleted)
						holder.Action.DynamicInvoke(args);
					else if (!holder.IsDeletedFromList)
					{
						listLocker.EnterWriteLock();
						delegatesList.Remove(cursor);
						holder.IsDeletedFromList = true;
						listLocker.ExitWriteLock();
					}
					Monitor.Exit(holder);
					cursor = next;
				}
			}
			catch
			{
				// clean up
				if (listLocker.IsReadLockHeld)
					listLocker.ExitReadLock();
				if (listLocker.IsWriteLockHeld)
					listLocker.ExitWriteLock();
				if (holder != null && Monitor.IsEntered(holder))
					Monitor.Exit(holder);
				throw;
			}
		}
		/// <summary>
		/// helper class
		/// </summary>
		class DelegateHolder
		{
			/// <summary>
			/// delegate to call
			/// </summary>
			public Delegate Action { get; private set; }
			/// <summary>
			/// flag shows if this delegate removed from list of calls
			/// </summary>
			public bool IsDeleted { get; set; }
			/// <summary>
			/// flag shows if this instance was removed from all lists
			/// </summary>
			public bool IsDeletedFromList { get; set; }
			/// <summary>
			/// Constuctor
			/// </summary>
			/// <param name="d"></param>
			public DelegateHolder(Delegate d)
			{
				Action = d;
			}
		}
	}
