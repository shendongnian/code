	public class CustomList<T>
    {
		private List<T> internalList = new List<T>();
        public T this[int index] { 
			get{ return internalList[index]; } 
			set{ internalList[index] = value;} 
		} //Error
        public void Add(T item)
        {
            // Method logic goes here.
        }
        public void Remove(T item)
        {
            // Method logic goes here.
        }
    }
