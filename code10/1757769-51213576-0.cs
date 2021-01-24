    protected void Page_Load(object sender, EventArgs e)
    {      
        var data = new Data.AcademicCodeRequestDBEntities();    
        var request = data.Requests
                            .Select(x => new Models.RequestIdentifier() 
                            {
                                id = x.id,
                                appName = x.appName,
                                requestIniatiationDate = x.requestIniatiationDate.ToString("yyyy-MM-dd"),
                                status = x.status,    
                            }).ToList();
        editGrid.DataSource = request;
        editGrid.DataBind();
    }
