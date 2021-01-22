        private void LoadGroup(GridView gv, string groupName, ManagerContext m)
    {
        VList<T> list = FetchInformation(m); //not sure if ManagerContext will get what you need
        if (Session[groupName] != null)
        {
           list.AddRange(List<T>Session[groupName]);
           gv.DataSource = list;
           gv.DataBind();
        }   
     
    }
