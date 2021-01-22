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
                IDisposable disposable = ( o as IDisposable );
			    if (disposable != null)
		                disposable.Dispose ();
			}
		}
		#endregion
	}
