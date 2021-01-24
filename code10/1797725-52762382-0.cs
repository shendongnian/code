    public async Task<ActionResult> Method(filterModel model)
    {
        VssConnection connection = new VssConnection(new 
        Uri(vstsCollectionUrl), new VssClientCredentials());
        WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();
        Wiql query = new Wiql() { Query = "SELECT [Id], [Title] FROM workitems WHERE [Work Item Type] = '" + model.state + "'" };
        WorkItemQueryResult queryResults = witClient.QueryByWiqlAsync(query).Result;
        if (queryResults == null || queryResults.WorkItems.Count() == 0)
        {
            Console.WriteLine("Query did not find any results");          
        }
    }
