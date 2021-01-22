    public class MyArrayList : IList, ICollection, IEnumerable, ICloneable
    {
    	private ArrayList arrayList = new ArrayList();
    
    	public event System.EventHandler RemovedItem;
        
    	public void RemoveAt(int index)
    	{
    		this.arrayList.RemoveAt(item);
    		if (RemovedItem != null) {
    			RemovedItem(this, new EventArgs());
    		}
    	}
    	
    	// implement required interface members...
    }
