    protected void Page_Load(object sender, EventArgs e)
    {
    	string[] filesindirectory = Directory.GetFiles(Server.MapPath("~/Images"));
    	List<String> images = new List<string>(filesindirectory.Count());
    
    	foreach (string item in filesindirectory)
    	{
    		images.Add(String.Format("~/Images/{0}", System.IO.Path.GetFileName(item)));
    	}
    
    	RepeaterImages.DataSource = images;
    	RepeaterImages.DataBind();
    }
