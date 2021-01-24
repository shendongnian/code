	public interface INameManager<T>
	{
		void requestNameChange(T item, string nameCandidate);
	}
	public interface INameManageable<T>
	{
		INameManager<T> getParent();
		setParent(INameManager<T> newParent);
		string getName(); // not relevant for the problem
		void setName(string name);
	}
	public class NameManager<T>: INameManager<T> where T: class, INameManageable<T>
	{
		readonly List<T> namedItems = new List<T>();
		
		void INameManager<T>.requestNameChange(INameManageable<T> item, string nameCandidate)
		{
		    // if necessary, modify nameCanditate to be a unique name in the list
			item.setName(nameCandidate);            
		}
		
		public T Add(T item)
		{
            // ...
            namedItems.Add(item);
			item.setParent(this);
        }
    }
