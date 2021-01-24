    public class UserLoginInfo
    {
        public string SerialNumber {get;set;} //you might want an int here instead
        public string Username {get;set;}
        public string Password {get;set;}
    }
    public partial class Form1 : Form
    {
        private List<UserLoginInfo> LoginInfo = new List<UserLoginInfo> {
            new UserLoginInfo() {SerialNumber = "1", Username = "Admin", Password = "123"}, 
            new UserLoginInfo() {SerialNumber = "2", UserName = "Admin2", Password = "456"}
        };
        private readonly string ConnectionString = @"Data Source=MIRAZ-PC\SQLEXPRESS;Initial Catalog=2DArrayIntoDatabaseTest;Integrated Security=True";
        private void SaveUserData(IEnumerable<UserLoginInfo> users)
        {
            string query = "INSERT INTO t(SerialNumber,UserName,Password) VALUES (@serial, @user, @pass);";
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(query, conn))
            {   
                cmd.Parameters.Add("@serial", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@user", SqlDbType.NVarChar, 20);  
                cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 20);
                conn.Open();
                foreach(var user in users)
                {
                    cmd.Parameters["@serial"].Value = user.SerialNumber;
                    cmd.Parameters["@user"].Value = user.UserName;
                    cmd.Parameters["@pass"].Value = user.Password;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private DataTable GetLoginData()
        {
            var result = new DataTable();
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand("SELECT * FROM t", conn))
            using (var sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(result);
            }
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                SaveUserData(LoginInfo);
                dataGridView1.DataSource = GetLoginData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }
    }
