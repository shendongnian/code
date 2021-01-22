    public class Form1 : Form
    {
        private string directoryPath;
    
        public Form1()
        {
            InitializeComponent();
            DirectoryInfo dinfo = new DirectoryInfo(@"K:\ases");
            FileInfo[] Files = dinfo.GetFiles("*.ssi", SearchOption.AllDirectories);
            foreach (FileInfo file in Files)
            {
                comboBox1.Items.Add(file.Name);
            }
    
            directoryPath = dinfo.FullName;
        }
    
        private void YourFunction()
        {
            string contents = File.ReadAllText(System.IO.Path.Combine(directoryPath, comboBox1.Text);
        }
    }
