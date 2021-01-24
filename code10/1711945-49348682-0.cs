        <script runat="server">
        public IEnumerable<Inventory> GetData()
        {
            return new InventoryRepo().GetAll();
        }
    	
    	protected void Page_Load(object sender, EventArgs e)            
    	{
    		if(!Page.IsPostBack)
    		{
    			carsGridView.DataSource = GetData();
    			carsGridView.DataBind();
    		}
    	}
        </script>
