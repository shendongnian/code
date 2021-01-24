	public interface INameManager
	{
		void requestNameChange(INameManageable item, string nameCandidate);
	}
	public interface INameManageable
	{
		INameManager getParent();
		setParent(INameManager newParent);
		string getName(); // not relevant for the problem
		void setName(string name);
	}
	public class NameManager<T>: INameManager where T: class, INameManageable
	{
		readonly List<T> namedItems = new List<T>();
		
		void INameManager.requestNameChange(INameManageable item, string nameCandidate)
		{
		    // if necessary, modify nameCanditate to be a unique name in the list
			item.setName(nameCandidate);            
		}
		
		public T Add(T item)
		{
            // ...
			item.setParent(this);
        }
    }
