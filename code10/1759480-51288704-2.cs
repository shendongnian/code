    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Item
    {
    	public int Itemid { get; set; }
    	public DateTime DayPurchased { get; set; }
    }
    
    public partial class Default : System.Web.UI.Page
    {
    	protected void itemsPerDayStore_ReadData(object sender, Ext.Net.StoreReadDataEventArgs e)
    	{
    		// Sample data. Replace items from database
    		IEnumerable<Item> Items = new Item[]
    		{
    			new Item { Itemid = 1, DayPurchased = DateTime.Today },
    			new Item { Itemid = 2, DayPurchased = DateTime.Today },
    			new Item { Itemid = 3, DayPurchased = DateTime.Today },
    			new Item { Itemid = 4, DayPurchased = DateTime.Today.AddDays(-1) },
    			new Item { Itemid = 5, DayPurchased = DateTime.Today.AddDays(-1) },
    			new Item { Itemid = 6, DayPurchased = DateTime.Today.AddDays(-2) }
    		};
    
    		itemsPerDayStore.DataSource = Items.GroupBy(x => x.DayPurchased.Day).Select(x => new
    		{
    			Day = x.Key,
    			Items = x.Count()
    		});
    
    		itemsPerDayStore.DataBind();
    	}
    }
