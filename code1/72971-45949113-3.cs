    public string GetEntityInJson()
    {
       JavaScriptSerializer j = new JavaScriptSerializer();
       var entityList = dataContext.Entitites.Select(x => new { ID = x.ID, AnotherAttribute = x.AnotherAttribute });
       return j.Serialize(entityList );
    }
