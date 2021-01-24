    using System.Collections.Generic;
    using System.Linq;
    
    public class Item
    {
    	public int Itemid { get; set; }
    	public string DayPurchased { get; set; }
    }
    
    public partial class Default : System.Web.UI.Page
    {
    	protected void itemsPerDayStore_ReadData(object sender, Ext.Net.StoreReadDataEventArgs e)
    	{
    		// Sample data. Replace with items from database.
    		IEnumerable<Item> Items = new Item[]
    		{
    			new Item { Itemid = 1, DayPurchased = "2018-01-01" },
    			new Item { Itemid = 2, DayPurchased = "2018-01-01" },
    			new Item { Itemid = 3, DayPurchased = "2018-01-01" },
    			new Item { Itemid = 4, DayPurchased = "2018-01-02" },
    			new Item { Itemid = 5, DayPurchased = "2018-01-02" },
    			new Item { Itemid = 6, DayPurchased = "2018-01-03" }
    		};
    
    		itemsPerDayStore.DataSource = Items.GroupBy(x => x.DayPurchased).Select(x => new
    		{
    			Day = x.Key,
    			Items = x.Count()
    		});
    
    		itemsPerDayStore.DataBind();
    	}
    }
