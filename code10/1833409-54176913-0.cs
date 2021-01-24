    public class dbLogin
    {
       public string userName{get;set;}
    }
    public void doTry()
        {
            db.ConnectionCheck();
            string sqlUname = "";
            string oracleUname = "";
            string usertesting = "select * from nayatable";
            db.cmd = new SqlCommand(usertesting, db.DBconnect);
            SqlDataReader myReader = db.cmd.ExecuteReader();
    List<dbLogin> dbData=new List<dbLogin>();
           
     if (myReader.Read())
            {
                dbLogin _dbLogin=new dbLogin();
                _dbLogin.userName = myReader["USERNAME"].ToString();
                textBox1.Text = sqlUname;
                dbData.Add(_dbLogin);
            }
    }
