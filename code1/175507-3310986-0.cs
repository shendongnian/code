	void Main()
	{
		var x=new MySpecialList<string>();
		x.Add("hello");
	}
	
	class MySpecialList<T>:List<T>
	{
		public new void Add(T item)
		{
			//special action here
			Console.WriteLine("added "+item);
			base.Add(item);
		}
	}
