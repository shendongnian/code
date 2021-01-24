    namespace Black
    {
        public partial class frmMain : Form
        {
            string sStayOnTop;
            
            public frmMain()
            {
                InitializeComponent();
                sStayOnTop = ConfigurationManager.AppSettings["StayOnTop"];
            }
    
        }
    }  
