	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			// reading data contained in the json filepath
			string jsonText = File.ReadAllText(FILENAME);
			//convert objects in json file to lists
			catalogueInstance = JsonConvert.DeserializeObject<Catalogue>(jsonText);
			ddlDelete.DataSource = catalogueInstance.books;
			ddlDelete.DataTextField = "title";
			ddlDelete.DataValueField = "id";
			//binding the data to Drop Down List
			ddlDelete.DataBind();
		}
	}
