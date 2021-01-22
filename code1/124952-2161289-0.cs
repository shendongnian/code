    public class ListScope : IDisposable
    {
		private IList list;
		public ListScope(IList list)
		{
			this.list = list;
		}
		#region IDisposable Members
		public void Dispose ()
		{
			foreach ( object o in this.list )
			{
				if ( o is IDisposable )
					( o as IDisposable ).Dispose ();
			}
		}
		#endregion
	}
