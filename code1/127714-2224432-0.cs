    using System.Configuration;
    using test.Properties;
    namespace test{
    public partial class mainForm : Form{
        
       public mainForm()
        {
            InitializeComponent();            
       
        }
        private void mainForm_Load(object sender, EventArgs e)
        {
            string connectionStr = ConfigurationManager.ConnectionStrings[this_index_is_up_to your_algorithm].ToString();
        }
    }
}
