	public interface INameManageable<T>
	{
		NameManager<T> getParent();
		setParent(NameManager<T> newParent);
		string getName();
		void setName(string name);
	}
	public class NameManager<T> where T: class, INameManageable<T>
	{
		readonly List<T> namedItems = new List<T>();
		
		public T Add(T item)
		{
            // ...
            namedItems.Add(item);
			item.setParent(this);
        }
    }
