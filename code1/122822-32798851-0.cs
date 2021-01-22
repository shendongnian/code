    public bool IsUserInRole(string username, string roleName, DataContext context)
    {          
       var result = context.aspnet_UsersInRoles_IsUserInRoleEF("/", username, roleName);
       //using here solved the issue
       using (var en = result.GetEnumerator()) 
       {
         if (!en.MoveNext())
           throw new Exception("emty result of aspnet_UsersInRoles_IsUserInRoleEF");
         int? resultData = en.Current;
         return resultData == 1;//1 = success, see T-SQL for return codes
       }
    }
