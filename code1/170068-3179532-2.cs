    List<EmployeeInfo> resultList = new List<EmployeeInfo>();
    foreach (EmployeeInfo p in empInfoList)
    {
       if (p.EmployeeName == EmployeeName.Text)
       {
          resultList.Add(p);
       }
    }
