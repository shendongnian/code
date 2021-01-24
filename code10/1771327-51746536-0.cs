    public partial class frmStackAnswers : Form
    {
        Timer tmr = new Timer();    //Timer to manage time
        Form childForm;             //Child form to display
        public frmStackAnswers()
        {
            InitializeComponent();
            Load += frmStackAnswers_Load;
        }
        void frmStackAnswers_Load(object sender, EventArgs e)
        {
            tmr.Interval = 60000;
            tmr.Tick += tmr_Tick;
            tmr.Start();
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            //Start child form between 10 AM to 4 PM if closed
            if (DateTime.Now.Hour > 10 && DateTime.Now.Hour < 16 && childForm == null)
            {
                childForm = new Form();
                childForm.Show();
            }
            //Close child form after 4 PM if it is opened
            else if (DateTime.Now.Hour > 16 && childForm != null)
            {
                childForm.Close();
                childForm = null;
            }
        }
    }
