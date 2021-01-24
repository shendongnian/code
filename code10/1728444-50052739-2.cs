    public string GetPayrollIdByEmployeeId(string source, string employeeId){
        return  source.Split(',')
              .Where(s => s.Substring(0, s.IndexOf(":", StringComparison.Ordinal)) == employeeId)
              .Select(s => s.Substring(s.IndexOf(":", StringComparison.Ordinal) + 1))
              .FirstOrDefault();
    }
