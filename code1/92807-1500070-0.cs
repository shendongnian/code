    protected void Page_Load(object sender, EventArgs e)
    {
        sring saveQueryString;
        if (!IsPostBack)
        {
            saveQueryString = Request.QueryString.ToString(); // join here - I doubt .ToString() will return the expected a=1?b=2?c=3 string
            // modify to your hearts content here...
            hiddenFormField.Text = saveQueryString;
        }
        else
            saveQueryString = Request.Form[hiddenFormField.Id];
    }
