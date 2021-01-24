       public class EmployeeRec
        {
            public int Employee_Id { get; set; }
            public string Name { get; set; }
            public string First_name { get; set; }
            public string active_or_not { get; set; }
        }
        public class QueryClass
        {
    
            public EmployeeRec[] ExecuteQueryNoWhereClause()
            {
    
                var sql = @"SELECT employee_id, name, first_name, active_or_not FROM t_personal";
    
                try
                {
                    using (IDbConnection _festeVerbindung = Data.Connection.GetConnection("My Connectionstring"))
                    {
    
                        var results = _festeVerbindung.Query<EmployeeRec>(sql).ToArray();
    
                        var activeOnly = results.Where(x => x.active_or_not == "Y");
    
                        return results;
    
                    }
    
                }
                catch (Exception oof)
                {
                    throw;
                }
            }
    
            public EmployeeRec[] ExecuteQueryWithWhereClause(string activeFlag)
            {
    
    
                var sql = @"SELECT employee_id, name, first_name, active_or_not FROM t_personal WHere active_or_not = @ACTIVE_FLAG";
    
                try
                {
                    using (IDbConnection _festeVerbindung = Data.Connection.GetConnection("My Connectionstring"))
                    {
    
                        var results = _festeVerbindung.Query<EmployeeRec>(sql, new { ACTIVE_FLAG = activeFlag }).ToArray();
    
                        foreach (var item in results)
                        {
    
                        }
                        return results;
    
    
                    }
    
                }
                catch (Exception oof)
                {
                    throw;
                }
            }
    
            public string[] ExecuteQueryReturnStringArray(string activeFlag)
            {
                StringBuilder sb = new StringBuilder();
                List<string> retArray = new List<string>();
    
                var sql = @"SELECT employee_id, name, first_name, active_or_not FROM t_personal WHere active_or_not = @ACTIVE_FLAG";
    
                try
                {
                    using (IDbConnection _festeVerbindung = Data.Connection.GetConnection("My Connectionstring"))
                    {
    
                        var results = _festeVerbindung.Query<EmployeeRec>(sql, new { ACTIVE_FLAG = activeFlag }).ToArray();
    
    
                        /*
                         * 
                         * There are better ways to do this, if you need to return a string array you should a Json or CSV text serializer like Servicestack.Text * 
                         * 
                         */
                        retArray.Add("employee_id, name, first_name, active_or_not");
    
                        foreach (var item in results)
                        {
                            retArray.Add(item.Employee_Id.ToString() + "," + item.Name + "," + item.First_name + "," + item.active_or_not);
                        }
                        return retArray.ToArray();
    
    
                    }
    
                }
                catch (Exception oof)
                {
                    throw;
                }
            }
    
        }
