    void Save<T>(List<T> saved, List<T> modified) where T: IUniqueIdentifiable
    {
        List<T> F_JoinedList = new List<T>();
        List<int> F_Modify = new List<int>();
        List<int> F_Create = new List<int>();
        List<int> F_Delete = new List<int>();
    
        //Modified Objects
        F_JoinedList = modified.Where(n => saved.Any(o => o.id == n.id)).ToList();
        foreach (T f in F_JoinedList)
        {
            T fs = saved.Single(x => x.id == f.id);
            if (!f.CompareEquals(fs))
                F_Modify.Add(f.id);
        }
    
        //Created Objects
        foreach (T f in modified)
        {
            bool vane = Convert.ToBoolean(saved.Where(f2 => f2.id == f.id).Count());
            if (!vane)
                F_Create.Add(f.id);
        }
    
        //Deleted Objects
        foreach (T f in saved)
        {
            bool vane = Convert.ToBoolean(modified.Where(f2 => f2.id == f.id).Count());
            if (!vane)
                F_Delete.Add(f.id);
        }
    
       ...
    
    }
    
        public interface IUniqueIdentifiable
        {
           id {get;}
        }
