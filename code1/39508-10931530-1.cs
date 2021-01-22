    namespace ChosenFile
    {
        public partial class Form1 : Form
        {
            // Form1 FormLoad
            //
            public Form1()
            {
                InitializeComponent();
                foreach (var Drives in Environment.GetLogicalDrives())
                {
                    DriveInfo DriveInf = new DriveInfo(Drives);
                    if (DriveInf.IsReady == true)
                    {
                        comboBox1.Items.Add(DriveInf.Name);
                    }
                }
            }
            // ComboBox1 (Drives)
            //
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (comboBox1.SelectedItem != null)
                {
                    ListDirectory(treeView1, comboBox1.SelectedItem.ToString());
                }
            }
            // ListDirectory Function (Recursive Approach):
            // 
            private void ListDirectory(TreeView treeView, string path)
            {
                treeView.Nodes.Clear();
                var rootDirectoryInfo = new DirectoryInfo(path);
                treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
            }
            // Create Directory Node
            // 
            private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
            {
                var directoryNode = new TreeNode(directoryInfo.Name);
                try
                {
                    foreach (var directory in directoryInfo.GetDirectories())
                        directoryNode.Nodes.Add(CreateDirectoryNode(directory));
                }
                catch (Exception ex)
                {
                    UnauthorizedAccessException Uaex = new UnauthorizedAccessException();
                    if (ex == Uaex)
                    {
                        MessageBox.Show(Uaex.Message);
                    }
                }
                return directoryNode;
            }
            // TreeView
            // 
            private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
            {
                listBox1.Items.Clear();
                listBox1.Refresh();
                PopulateListBox(listBox1, treeView1.SelectedNode.FullPath.ToString(), "*.pdf");
            }
            // PopulateListBox Function
            // 
            private void PopulateListBox(ListBox lsb, string Folder, string FileType)
            {
                try
                {
                    DirectoryInfo dinfo = new DirectoryInfo(Folder);
                    FileInfo[] Files = dinfo.GetFiles(FileType);
                    foreach (FileInfo file in Files)
                    {
                        lsb.Items.Add(file.Name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while attempting to load the file. The error is:"
                                    + System.Environment.NewLine + ex.ToString() + System.Environment.NewLine);
                }
            }
            // ListBox1
            //
            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (listBox1.SelectedItem != null)
                {
                    //do smt here!
                    MessageBox.Show(listBox1.SelectedItem.ToString());
                }
            }
        }
    }
