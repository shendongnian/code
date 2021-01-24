       //1.Request view query
       var list = ctx.Web.Lists.GetByTitle(listName);
       var view = list.Views.GetByTitle(viewName);
       ctx.Load(view);
       ctx.ExecuteQuery();
       //2.construct list query from view query and retrieve items 
       var qry = new CamlQuery();
       qry.ViewXml = String.Format("<View><Query>{0}</Query></View>", view.ViewQuery); 
       var items = list.GetItems(qry);
       ctx.Load(items);
       ctx.ExecuteQuery(); 
