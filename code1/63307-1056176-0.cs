    public class MyItem {
    	public string ID { get; set; }
               :
    }
    
    public class MyList : ICollection<MyItem> {
    	private Dictionary<string,MyItem> items;
    	public MyList() {
    		items = new Dictionary<string, MyItem>();
    	}
    	void Add(MyItem item) {
    	     items.Add(item.ID, item);
    	}
    		:
    }
