    using Microsoft.SharePoint.Client;
    using Microsoft.SharePoint.Client.Search.Query;
    
    // Connection to SharePoint.
    var context = new ClientContext(url);
	
	var securePassword = new System.Security.SecureString();
	foreach (var c in password.ToCharArray())
	{
		securePassword.AppendChar(c);
	}
	context.Credentials = new SharePointOnlineCredentials(username, securePassword);
    
    // Pull sites the user has access to.
    var query = new KeywordQuery(context);
    query.QueryText = "WebTemplate:GROUP";
    query.SelectProperties.Add("Title");
    query.SelectProperties.Add("Path");
    query.RowsPerPage = 1000;
    var results = new SearchExecutor(context).ExecuteQuery(query);
    context.ExecuteQuery();
    // Process results...
    // (May want to add some error/null condition checks.)
    var resultTable = results.Value.First();
    foreach (var result in resultTable.ResultRows)
    {
        Console.WriteLine(string.Format("Title: {0} -- Path: {1}",
            result["Title"].ToString(),
            result["Path"].ToString()));
    }
