    public Dictionary<String, int> processData(IEnumerable<string> lines)
    {
        List<EmployeeSalary> list = new List<EmployeeSalary>();
        foreach(var line in lines)
        {
            string[] temp = line.Split(',');
            EmployeeSalary tempObj = new EmployeeSalary();
            tempObj.EmployeeID = int.Parse(temp[0]);
            tempObj.Name = temp[1];
            tempObj.Department = temp[2];
            tempObj.Salary = int.Parse(temp[3]);
            list.Add(tempObj);
        }
        var query = (from f in list group f by f.Department into g select g);
        Dictionary<String, int> retVal  = 
        query.ToDictionary(x => x.Key, x => x.OrderByDescending(c=>c.Salary).Select(c=>c.EmployeeID).FirstOrDefault());
        return retVal;
    }
