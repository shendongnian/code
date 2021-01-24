    public partial class Form1 : Form
    {
        //common (single) object of status calss
        StatusClass m_statusClass;
        public Form1()
        {
            InitializeComponent();
            //creating this object only once while software starts
            // we can even serialize- deserialize this object 
            m_statusClass = new StatusClass();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //passing common (single) object of status class in this form 
            FrmSaveCSV frmSaveCSV = new FrmSaveCSV(m_statusClass);
            frmSaveCSV.Show();
        }
    }
