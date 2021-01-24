    public class UserClass
    {
        public string fname { get; set; }
        public int age { get; set; }
    }
    [WebMethod]
    public static string doSomething(UserClass obj)
    {      
       SqlConnection con = new SqlConnection("server=.; Initial Catalog = jds; Integrated Security= true;");
        string sql = "insert into record values('" + obj.fname + "','" + obj.age + "')";
        SqlCommand cmd = new SqlCommand(sql, con);
         con.Open();
         cmd.ExecuteNonQuery();
         con.Close();
         return "Sucess";
    }
