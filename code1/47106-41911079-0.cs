		//
		public List<R> GetAllItems<R>() where R : IBaseRO, new() {
			var list = new List<R>();
			using ( var wl = new ReaderLock<T>( this ) ) {
				foreach ( var bo in this.items ) {
					T t = bo.Value.Data as T;
					R r = new R();
					r.Initialize( t );
					list.Add( r );
				}
			}
			return list;
		}
