    public class Foo
    {
    private List<string> _SomeCollection;
    public event EventHandler Added;
    
    public void Add(string item)
    {
        SomCollection.Add(item);
    	OnAdd();
    
    }
    
    private void OnAdd()
    {
    	if (Added != null)
        {
    	    Added.Invoke(this, EventArgs.Empty);
    	}
    }
    }
