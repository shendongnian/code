    Web web = clinetContext.Web;
    clinetContext.Load(web);
    web.Context.ExecuteQuery();
    List documentsList = web.Lists.GetByTitle(documentLibrary);
    clinetContext.Load(documentsList);
    web.Context.ExecuteQuery();
