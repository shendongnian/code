    var roleCodes = new List<string>{"R0090","R0003","R0084","R0069","R0006","R0054"};
    
    var users = Users.Where(x => x.IsActive && roleCodes.Contain(x.RoleCode))
                     .OrderBy(x => x.UserName)
                     .ToList();
    // or
    var user = from u in Users
               where u.IsActive && roleCodes.Contains(u.RoleCode)
               orderby u.UserName
               select u;
