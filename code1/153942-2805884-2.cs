    using System;
    using System.IO;
    using System.Windows.Forms;
    namespace Test
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void PopulateGrid()
        {
            DirectoryInfo dir = new DirectoryInfo(fileSystemWatcher1.Path);
            dataGridView1.DataSource = dir.GetFiles();
        }
        private void fileSystemWatcher1_CreatedDeletedChanged(object sender, FileSystemEventArgs e)
        {
            PopulateGrid();
        }
        
        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            PopulateGrid();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
    }
