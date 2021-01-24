    [webmethod(true)]
    public string FillList()
    {
    string str="";
    DataTable dt= new DataTable();
    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT Name,Nick FROM dbBase ORDER BY id ASC"))
            {
                using (MySqlDataAdapter da = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    da.SelectCommand = cmd;
                    da.fill(dt);
                }
            } 
          if(dt.row.count!=0 && dt!=null){
          return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
          }
          else{
          return "";
          }
        }
    }
