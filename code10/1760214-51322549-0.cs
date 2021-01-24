    ClientContext ctx = new ClientContext("http://sp2013/sites/team");
    var web = ctx.Web;
    var list = web.Lists.GetByTitle("TestStartWorkflow");
    var query = new CamlQuery();
    query.ViewXml = "<View Scope=\"RecursiveAll\"></View>";
    var items = list.GetItems(query);
    ctx.Load(items,i=>i.Include(item=>item.AttachmentFiles));
    ctx.ExecuteQuery();
    var flag = items.Any(i=>i.AttachmentFiles.Count>0);
