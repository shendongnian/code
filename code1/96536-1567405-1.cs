    public static IQueryable<Building> WithStatus(this IQueryable<Building> qry,  
    IList<BuildingStatuses> buildingStatus) 
    { 
        return from v in qry
               where ContainsStatus(v.Status)
               select v;
    } 
    private bool ContainsStatus(v.Status)
    {
        foreach(Enum value in Enum.GetValues(typeof(buildingStatus)))
        {
            If v.Status == value.GetCharValue();
                return true;
        }
        
        return false;
    }
