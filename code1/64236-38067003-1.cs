    // Non-generic base class allows listing tables together
    abstract class Datatable
    {
        Datatable(Type storedClass)
	    {
		  StoredClass = storedClass;
	    }
    
        Type StoredClass { get; private set; }
    }
    // Generic inheriting class
    abstract class Datatable<T>: Datatable, IDatatable<T>
    {
        protected Datatable()
	        :base(typeof(T))
        {
	    }
    }
