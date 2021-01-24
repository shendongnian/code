    public partial class WebForm1 : System.Web.UI.Page
    {
        //You should really pull this from your web.config
        string connectionString = "(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\David\\Desktop\\WebApplication5\\WebApplication5\\App_Data\\Database2.mdf\";Integrated Security=True";;
        static int count = 1;
        static int max = 2;
        static String sqlQuery = "Select * from Footballer";
        static bool firstTime = true;
    
        protected void Page_Load(object sender, EventArgs e)
        {            
            mycount();
    
            if (firstTime == true)
            {
                displayData();
               firstTime = false;
            }
        }
    
        protected void mycount()
        {   // count no of els in table
            max = 0;
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.open();
                using(var cmd = cn.CreateCommand())
                {
                   cmd.CommandText = sqlQuery;
                   var reader = cmd.ExecuteReader();
                   while (reader.Read()) max++;
                   reader.Close();
                }
            }
        }
    
        protected void displayData()
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.open();
                using(var cmd = cn.CreateCommand())
                {  
                   cmd.CommandText = sqlQuery;
                   var reader = cmd.ExecuteReader();
                   for (int i = 0; i < count; i++) reader.Read();
                     TextBox1.Text = "" + reader[0];
                     TextBox2.Text = "" + reader[1];
                     TextBox5.Text = "" + reader[2];
                     TextBox6.Text = "" + reader[3];
                     TextBox7.Text = "" + reader[4];
                     TextBox8.Text = "" + reader[5];
                   reader.Close();
             }
           }
        }
    
        protected void deleteData()
        {
            //Add A break point here to ensure the method is hit
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.open();
                using(var cmd = cn.CreateCommand())
                {            
                  string query = "DELETE from [Footballer] where [PlayerName] = @name";
                  cmd.CommandText = query;
    
                  string name = TextBox4.Text;    
                  //When stepping through in debug mode, make sure
                  //name is what you expect.
                  cmd.Parameters.AddWithValue("@name", name);
    
                 cmd.ExecuteNonQuery(); 
                }
           }
        }
