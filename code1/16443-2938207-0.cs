    public partial class Form1 : Form
    {
        string fileName = "";
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string path = "";
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Attach customer proposal document";
            fDialog.Filter = "Doc Files|*.doc|Docx File|*.docx|PDF doc|*.pdf";
            fDialog.InitialDirectory = @"C:\";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = System.IO.Path.GetFileName(fDialog.FileName);
                path = Path.GetDirectoryName(fDialog.FileName);
                textBox1.Text = path + "\\" + fileName;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                NetworkCredential nc = new NetworkCredential("erandika1986", "123");
                Uri addy = new Uri(@"\\192.168.2.4\UploadDocs\"+fileName);
                client.Credentials = nc;
                byte[] arrReturn = client.UploadFile(addy, textBox1.Text);
                MessageBox.Show(arrReturn.ToString());
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }
    }
}
