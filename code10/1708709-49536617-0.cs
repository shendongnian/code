    List<string> years = new List<string>();
 
    for (int i = 0; i < vm.taxYears.Count; i++)
    {
         years.Add(vm.taxYears[i].StartDate.Year + "/" + vm.taxYears[i].EndDate.Year);
    }
    Session["years"] = years;
