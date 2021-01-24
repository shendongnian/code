    var list = ctx.Web.Lists.GetByTitle(listName);
    var view = list.Views.GetByTitle(viewName);
    ctx.Load(view);
    ctx.ExecuteQuery();
    
    var qry = new CamlQuery();
    qry.ViewXml = String.Format("<View><Query>{0}</Query></View>", view.ViewQuery);
    var result = list.RenderListData(qry.ViewXml);
    ctx.ExecuteQuery();
    
    //parse json and print
    var data = JObject.Parse(result.Value);
    foreach (var row in data["Row"])
    {
        Console.WriteLine(row["Status"]);
    }
  
