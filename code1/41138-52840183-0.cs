    public partial class Form1 : MetroForm
    {
        SqlConnection cn;
        SqlCommand cm;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!CheckDatabaseExist())
            {
                GenerateDatabase();
            }
        }
        private bool CheckDatabaseExist()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SalmanTradersDB;Integrated Security=true");
            try
            {
                con.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void GenerateDatabase()
        {
            try
            {
                cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("drop databse {0}", "SalmanTradersDB"));
                cm = new SqlCommand(sb.ToString() , cn);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
            }
            catch
            {
            }
            try
            {
                //Application.StartupPath is the location where the application is Installed
                //Here File Path Can Be Provided Via OpenFileDialog
                if (File.Exists(Application.StartupPath + "\\script.sql"))
                {
                    string script = null;
                    script = File.ReadAllText(Application.StartupPath + "\\script.sql");
                    string[] ScriptSplitter = script.Split(new string[] { "GO" }, StringSplitOptions.None);
                    using (cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True"))
                    {
                        cn.Open();
                        foreach (string str in ScriptSplitter)
                        {
                            using (cm = cn.CreateCommand())
                            {
                                cm.CommandText = str;
                                cm.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch
            {
            }
           
        }
    }
