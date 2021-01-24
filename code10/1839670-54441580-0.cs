     <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
    
    <appSettings>
    
    <add key="ConnectionString" value="Data Source=MY-PC;Initial Catalog=DB2013;User ID=sa;Password=MYSQL123" />
    
    </appSettings>
    
    </configuration>
    using System.Configuration;
    using System.Data.SqlClient;
    
    namespace Test
    {
    public partial class Form1: Form
    {
       SqlConnection MyConnection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
    
        public Form1()
        {
            InitializeComponent();
    
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               MyConnection.Open();
            }
            catch (Exception)
            {
    
                throw;
            }
    }
}
