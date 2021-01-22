    public IList<int> ModuleIds
    {
       get
       {
           string moduleIds = Convert.ToString(ViewState["ModuleIds"])
           IList<int> list = new Collection<int>();
           foreach(string moduleId in moduleIds.split(","))
           {
              list.Add(Convert.ToInt32(moduleId));
           }
          return list;
       }
    }
