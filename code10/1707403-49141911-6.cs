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
        // this is called "explicit interface implementation";
    	// basically means "private", unless somebody explicitly
        // casts us to the interface (so it's at least discouraged)
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
