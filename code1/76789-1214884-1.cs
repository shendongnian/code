    public partial class SortList : System.Web.UI.Page
    {
    	[Serializable]
    	public class MyItem
    	{
    		public Guid Id { get; set; }
    		public string Name { get; set; }
    
    		public MyItem(Guid id, string name)
    		{
    			Id = id;
    			Name = name;
    		}
    	}
    
    	protected List<MyItem> MyList
    	{
    		get
    		{
    			if (ViewState["myClass"] == null)
    				ViewState["myClass"] = new List<MyItem>();
    			return (List<MyItem>)ViewState["myClass"];
    		}
    	}
    
    	protected void AddItem(Guid id, string name)
    	{
    		MyList.Add(new MyItem(id, name));
    		RList.DataSource = MyList;
    		RList.DataBind();
    	}
    
    	protected void ButtonClick_AddItem(object sender, EventArgs e)
    	{
    		AddItem(Guid.NewGuid(), DateTime.Now.Ticks.ToString());
    	}
    }
