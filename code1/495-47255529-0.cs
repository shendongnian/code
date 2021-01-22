		public static void Main()
		{
			NoRemoveList<string> testList = ListFactory<string>.NewList();
			testList.Add(" this is ok ");
			// not ok
			//testList.RemoveAt(0);
		}
		public interface NoRemoveList<T>
		{
			T this[int index] { get; }
			int Count { get; }
			void Add(T item);
		}
		public class ListFactory<T>
		{
			private class HiddenList: List<T>, NoRemoveList<T>
			{
				// no access outside
			}
			public static NoRemoveList<T> NewList()
			{
				return new HiddenList();
			}
		}
