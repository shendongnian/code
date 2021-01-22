    public static IQueryable Cast(this IQueryable source, string type)
    {
        switch (type)
        {
            case "TofiDataCollection.Service.TofiEntity.Obj":
                return source.Cast<Obj>();
        }
        return source;
    }
