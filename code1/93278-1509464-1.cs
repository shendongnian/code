    public static MyDataStructure isQuestionnaireComplete(string strHash)
    {
        SqlConnection con = Sql.getConnection();
    
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT IsComplete, FirstString, SecondString, ThridString FROM UserDetails WHERE Hash='" + strHash + "' AND IsComplete=1");
            cmd.Connection = con;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            da.Fill(dt);
            
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                // Populate object from data table
                DataRow row = dt.Rows[0];
                
                retun new MyDataStructure
                  {
                    MyFirstString = row["FirstString"],
                    MySecondString = row["SecondString"],
                    MyThirdString = row["ThridString"]
                  };
            }
        }
        catch
        {
            //TODO:log error
            return false;
        }
        finally
        {
            con.Close();
        }
    }
    
    public class MyDataStructure
    {
      public string MyFirstString { get; set; }
      public string MySecondString { get; set; }
      public string MyThirdString { get; set; }
    }
