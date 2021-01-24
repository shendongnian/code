    using System.Data.SQLite;
    using System.Net.NetworkInformation;
    using MySql.Data.MySqlClient;
    namespace super
    {
    public partial class neworupload : Form
    {
        SQLiteConnection con = new SQLiteConnection(@"connection string");
        MySqlConnection conn;
        String connstring;
        public neworupload()
        {
            InitializeComponent();
        }
        
       
        private void button1_Click(object sender, EventArgs e)
        {
            bool connection = NetworkInterface.GetIsNetworkAvailable();
            if (connection == true)
            {
              //  MessageBox.Show("available");
                connstring = "SERVER=your ip;PORT=port;DATABASE=dbname;UID=userid;PASSWORD=password;SslMode = none;";
                try
                {
                    //  con = new SQLiteConnection();
                    con.Open();
                    MessageBox.Show("Connection success");
                    String qu = "select * from users ";
                    SQLiteCommand cmd = new SQLiteCommand(qu, con);
                    SQLiteDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                       
                        String a = data["iduser"].ToString();
                        String b = data["name"].ToString();
                        String c = data["type"].ToString();
                        String d = data["email"].ToString();
                        String f = data["hash"].ToString();
                        Console.WriteLine(a);
                        Console.WriteLine(b);
                        Console.WriteLine(c);
                        Console.WriteLine(d);
                        Console.WriteLine(f);
                        conn = new MySqlConnection();
                        conn.ConnectionString = connstring;
                        conn.Open();
                        String qudemo = "select iduser from users";
                        Console.WriteLine("dddd" + qudemo);
                        if(qudemo)
                        String qu1 = "INSERT INTO users(iduser,name,type,email,hash) Values(@iduser,@name,@type,@email,@hash)";
                      
                        MySqlCommand cmd1 = new MySqlCommand(qu1, conn);
                        cmd1.Parameters.AddWithValue("@iduser", a);
                        cmd1.Parameters.AddWithValue("@name", b);
                        cmd1.Parameters.AddWithValue("@type", c);
                        cmd1.Parameters.AddWithValue("@email", d);
                        cmd1.Parameters.AddWithValue("@hash", f);
                        cmd1.ExecuteNonQuery();
                        Console.WriteLine(qu1);
                        conn.Close();
                    }
                    con.Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                MessageBox.Show("Check connectivity and try again!");
            }
         
        }
    }
     }
