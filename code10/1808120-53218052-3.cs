	protected void Page_Load(object sender, EventArgs e)
	{
		Load_Topic1();
		topic1.SelectedValue = Page.IsPostBack
			? Request.Form[topic1.UniqueID]
			: ((string)Session["Topic1"] ?? "0");
		Load_Section1();
		section1.SelectedValue = Page.IsPostBack
			? Request.Form[section1.UniqueID]
			: ((string)Session["Section1"] ?? "0");
	}
