		class DisposableList<T> : List<T>, IDisposable
			where T : IDisposable
		{
			public bool IsDisposed = false;
			public T BeginUsing(T item) { base.Add(item); return item; }
			public void Dispose()
			{
				for (int ix = this.Count - 1; ix >= 0; ix--)
				{
					try { this[ix].Dispose(); }
					catch (Exception e) { Logger.LogError(e); }
					this.RemoveAt(ix);
				}
				IsDisposed = true;
			}
		}
