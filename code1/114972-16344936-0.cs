    static class Extensions
	{
		public static void Sort<T>(this ObservableCollection<T> collection) where T : IComparable
		{
			List<T> sorted = collection.OrderBy(x => x).ToList();
			for (int i = 0; i < sorted.Count(); i++)
				collection.Move(collection.IndexOf(sorted[i]), i);
		}
	}
    public class MyObject: IComparable
	{
		public int CompareTo(object o)
		{
			MyObject a = this;
			MyObject b = (MyObject)o;
			return Utils.LogicalStringCompare(a.Title, b.Title);
		}
        public string Title;
    }
      .
      .
      .
    myCollection = new ObservableCollection<MyObject>();
    //add stuff to collection
    myCollection.Sort();
