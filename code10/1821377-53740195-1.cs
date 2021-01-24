    // ...
    
    popup = new Popup
    {
    	title = p.devId,
    	subtitle = "Laatst geupdate: " + p.Lastupdate + " uur geleden.",
    	imageUrl = "<URL>",
    
    	items = new List<Item>
    	{
    		new Item
    		{
    			type = "text",
    			label = "text",
    			value = "text items"
    		}
    	}
    }
    
    // ...
    
    public class Popup
    {
    	public string title;
    	public string subtitle;
    	public string imageUrl;
    	public List<Item> items;
    }
    
    public class Item
    {
    	public string type;
    	public string label;
    	public string value;
    }
    
    // ...
