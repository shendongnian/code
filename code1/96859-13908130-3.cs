    public class SyncronisedList<T> : IList<T> {
		private readonly ReaderWriterLockSlim _threadLock;
		private readonly IList<T> _internalList;
	
		public SyncronisedList() : this(new List<T>()) {
		}
		public SyncronisedList(IList<T> internalList) {
			_internalList = internalList;
			_threadLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
		}
		private U Read<U>(Func<U> function) {
			using (EnterReadScope())
				return function();
		}
		private void Read(Action action) {
			using (EnterReadScope())
				action();
		}
		private U Write<U>(Func<U> function) {
			using (EnterWriteScope())
				return function();
		}
		private void Write(Action action) {
			using (EnterWriteScope())
				action();
		}
		public IDisposable EnterReadScope() {
			return new Scope<T>(this, false);
		}
		public IDisposable EnterWriteScope() {
			return new Scope<T>(this, true);
		}
		public T this[int index] {
			get { return Read(() => _internalList[index]); }
			set { Write(() => _internalList[index] = value); }
		}
		public int IndexOf(T item) { return Read(() => _internalList.IndexOf(item)); }
		public void Insert(int index, T item) { Write(() => _internalList.Insert(index, item)); }
		public void RemoveAt(int index) { Write(() => _internalList.RemoveAt(index)); }
		public void Add(T item) { Write(() => _internalList.Add(item)); }
		public void Clear() { Write(() => _internalList.Clear()); }
		public bool Contains(T item) { return Read(() => _internalList.Contains(item)); }
		public int Count { get { return Read(() => _internalList.Count); } }
		public bool IsReadOnly { get { return Read(() => _internalList.IsReadOnly); } }
		public void CopyTo(T[] array, int arrayIndex) { Read(() => _internalList.CopyTo(array, arrayIndex)); }
		public bool Remove(T item) { return Write(() => _internalList.Remove(item)); }
		public IEnumerator<T> GetEnumerator() { return Read(() => _internalList.GetEnumerator()); }
		IEnumerator IEnumerable.GetEnumerator() { return Read(() => (_internalList as IEnumerable).GetEnumerator()); }
		private class Scope<U> : IDisposable {
			private readonly SyncronisedList<U> _owner;
			private readonly bool _write;
			internal Scope(SyncronisedList<U> owner, bool write) {
				_owner = owner;
				_write = write;
				if (_write)
					_owner._threadLock.EnterWriteLock();
				else
					_owner._threadLock.EnterReadLock();
			}
			public void Dispose() {
				if (_write)
					_owner._threadLock.ExitWriteLock();
				else
					_owner._threadLock.ExitReadLock();
			}
		}
	}
