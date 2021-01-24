	public interface INameManageable<T>
	{
		NameManager<T> getParent();
		string getName();
        // derived class should use explicit interface implementation
        // so that no-one from external can fiddle with name or parent
		setParent(NameManager<T> newParent);
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
    public class X: INameManageable<X>
    {
        // publicly accessible
		public NameManager<T> getParent() {/* ... */}
		public string getName() {/* ... */}
		// formally "private", public access is discouraged
        // through necessity of explicit cast to the interface,
        // so not everyone can mess with ownership and name
		void INameManageable<T>.setName(string name) {/* ... */}
		void INameManageable<T>.setParent(NameManager<T> nameManager) {/* ... */}
    }
    public class Y: INameManageable<Y>
    {
        // ... same here ...
    }
    public class ABunchOfNameManagers
    {
        NameManager<X> anXNameManager;
        NameManager<Y> aYNameManager;
    }
