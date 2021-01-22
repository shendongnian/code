	//Untested code
	
	interface IEnumerableEx<T> : IEnumerable<T>
	{
		public int Count {get;}
	}
	
	class ListWrapper<T> : IEnumerableEx<T>, List<T>
	{
		public int IEnumerableEx<T>.Count
		{
		    get
			{
			    return this.Count;
			}
		}
	}
	
	//Usage:
	
	class MyClass
	{
	    ListWrapper<int> list = new ListWrapper<int>();
		
		public IEnumerableEx<int> GetList()
		{
		    return (IEnumerableEx<int>)list;
		}
	}
