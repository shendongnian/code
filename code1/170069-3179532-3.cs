    string criteria = EmployeeName.Text.Trim().ToLower();
    List<EmployeeInfo> resultList = empInfoList.FindAll(
       delegate(EmployeeInfo p)
       {
          return p.EmployeeName.ToLower().Contains(criteria);
       }
    );
