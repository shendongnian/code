    public partial class Form1 : Form
    {
        //common (single) object of status calss
        StatusClass m_statusClass;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //passing common (single) object of status class in this form 
            FrmSaveCSV frmSaveCSV = new FrmSaveCSV(m_statusClass);
            frmSaveCSV.Show();
        }
        //On software load, we de-serialize last status form file
        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = "Status.dat";
            if (File.Exists(fileName))
            {
                Stream s = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                IFormatter f1 = new BinaryFormatter();
                try
                {
                    m_statusClass = (StatusClass)f1.Deserialize(s);
                }
                catch
                {
                    s.Close();
                    m_statusClass = new StatusClass();
                }
                s.Close();
            }
            else
                m_statusClass = new StatusClass();
        }
        //Of software closing we serialize current stats in file.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string fileName = "Status.dat";
            if (File.Exists(fileName))
                File.Delete(fileName);
            using (Stream s = new FileStream("Status.dat", FileMode.Create))
            {
                IFormatter f2 = new BinaryFormatter();
                f2.Serialize(s, m_statusClass);
                s.Close();
                s.Dispose();
            }
        }
    }
