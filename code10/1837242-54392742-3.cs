		public DisposeArr(long size)
        {
            Data = new byte[size];
			_allData.TryAdd(GetHashCode(), this);
        }
		
		public static CollectAll()
		{
		   for (var item in _allData)
		   {
		      _allData.Value.Dispose();
		   }
		}
		
		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
                return;
            if (disposing)
            {
			   ...
			   _allData.TryRemove(GetHashCode(), out DisposeArr tmpDisposeArr);
			}
		}
		
    }
