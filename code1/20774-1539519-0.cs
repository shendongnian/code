	  [ComVisible(true)]
	  [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	  public interface IRequest
	  {
		IRequestDictionary ManagedQueryString { get; } // Property to use form managed code
		object QueryString(object key); // Property to use from COM or unmanaged code
	  }
	  [ComVisible(true)]
	  [ClassInterface(ClassInterfaceType.None)]
	  public class TestRequest : IRequest
	  {
		private IRequestDictionary _queryString = new RequestDictionary();
		public IRequestDictionary ManagedQueryString
		{
		  get { return _queryString; }
		}
		public object QueryString(object key)
		{
		  if (key is System.Reflection.Missing || key == null)
			return _queryString;
		  else
			return _queryString[key];
		}
	  }
	  [ComVisible(true)]
	  [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	  public interface IRequestDictionary : IEnumerable
	  {
		[DispId(0)]
		object this[object key]
		{
		  [DispId(0)]
		  get;
		  [DispId(0)]
		  set;
		}
		int Count { get; }
	  }
	  [ComVisible(true)]
	  [ClassInterface(ClassInterfaceType.None)]
	  public class RequestDictionary : IRequestDictionary
	  {
		private Hashtable _dictionary = new Hashtable();
		public object this[object key]
		{
		  get { return _dictionary[key]; }
		  set { _dictionary[key] = value; }
		}
		public int Count { get { return _dictionary.Count; } }
		#region IEnumerable Members
		public IEnumerator GetEnumerator()
		{
		  throw new NotImplementedException();
		}
		#endregion
	  }
