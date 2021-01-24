    public class RoleContext  
    {  
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MYConnector"].ToString());  
        public IEnumerable<RoleTable> GetRoleList()  
        {  
            // it would be good if you put inline query in procedure
            string query = "SELECT RoleName,RoleId FROM RoleTable";  
            var result = con.Query<RoleTable>(query);  
            return result;  
       }  
    }
    
