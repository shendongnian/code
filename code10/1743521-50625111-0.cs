    void Main()
    {
    	var items = new ItemCountList();
    	items.AddItem("item0");
    	items.AddItem("item1");
    	items.AddItem("item2");
    	items.AddItem("item0");
    	
    	items.ShowItems();
    }
    public class ItemCountList {
    	private List<SimpleItem> itemList;
    	public ItemCountList() {
    		itemList = new List<SimpleItem>();
    	}
    	public void DeleteItem(string value) {
    		var item = itemList.FirstOrDefault(b => b.Value == value);
    		if (item != null) {
    			item.Count--;
    			if (item.Count == 0)
    				itemList.Remove(item);
    		}
    	}
    	public void AddItem(string value) {
    		var item = itemList.FirstOrDefault(b => b.Value == value);
    		if (item != null)
    			item.Count++;
    		else
    			itemList.Add(new SimpleItem {
    				Value = value,
    				Count = 1
    			});
    	}
    	public void ShowItems() {
    		foreach (var a in itemList) {
    			Console.WriteLine(a.Value + "(" + a.Count + ")");
    		}
    	}
    }
    public class SimpleItem {
    	public int Count {get; set;}
    	public string Value {get; set;}
    }
