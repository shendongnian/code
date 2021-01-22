    Employee e;
    try {
       
       IEnumerable<Team> teams = Team.GetTeamsByEmployee(e);
       if (teams.Count() > 0) {
           throw new Exception("Employee is a part of team "+ String.Join(",", teams.Select(o => o.Name).ToArray());
       }
       IEnumerable<Employee> managingEmployees = Employee.GetEmployeesImManaging(e);
       if (managingEmployees.Count() > 0) {
           throw new Exception("Employee is manager for the following employees "+ String.Join(",", managingEmployees.Select(o => o.Name).ToArray());
       }
    
       Employee.Delete(e);
    } catch (Exception e) {
       // write out e
    }
