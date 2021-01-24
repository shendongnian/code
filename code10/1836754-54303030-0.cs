    List<RFPModel> lst = RFPModel.GetAll();  //ALL
    var lookup = lst.ToLookup(x=>x.StatusID);
    lblActive.InnerText = lookup[(int)ProjectStatus.Project_Active].Count();
    lblCompleted.InnerText = lookup[(int)ProjectStatus.Project_Completed].Count();
    and so on  ......
