    protected void Page_Load(object sender, EventArgs e)
    {
    var data = new Data.AcademicCodeRequestDBEntities();
    var request = data.Requests.Select(x => new 
                        {
                            x.appName, 
                            x.requestIniatiationDate.ToString("d"), 
                            x.status, 
                            x.id
                        }).ToList()
                        .Select(x => new Models.RequestIdentifier() 
                        {
                            id = x.id,
                            appName = x.appName,
                            requestIniatiationDate = x.requestIniatiationDate.ToString("d"),
                            status = x.status,
                        });
    editGrid.DataSource = request;
    editGrid.DataBind();
}
