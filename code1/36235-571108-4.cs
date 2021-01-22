    protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString["idx"] != null)
		{
			listView.DataBinding +=new EventHandler(ChangeSelectedIndex);
		}
		if (!Page.IsPostBack)
		{
			BindData();
		}
	}
	void ChangeSelectedIndex(object sender, EventArgs e)
	{
		int idx = Convert.ToInt32(Request.QueryString["idx"]);
		if (idx >= 0 && idx < Enumerable.Count(listView.DataSource as IEnumerable<int>))
		{
			listView.SelectedIndex = idx;
		}
		else
		{
			throw new ArgumentOutOfRangeException();
		}
		
	}
	protected void BindData()
	{
		listView.DataSource = System.Linq.Enumerable.Range(1, 10);
		listView.DataBind();
	}
