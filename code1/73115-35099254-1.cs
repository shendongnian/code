    private void Form2_Load(object sender, EventArgs e)
    {
        treeView1.CheckBoxes = true;
            
        foreach (TreeNode node in treeView1.Nodes)
        {
            node.Checked = true;
        }
            
        string[] drives = Environment.GetLogicalDrives();
           
        foreach (string drive in drives)
        {
            // treeView1.Nodes[0].Nodes[1].Checked = true;
            DriveInfo di = new DriveInfo(drive);
            int driveImage;
            switch (di.DriveType)   
            {
                case DriveType.CDRom:
                    driveImage = 3;
                    break;
                case DriveType.Network:
                    driveImage = 6;
                    break;
                case DriveType.NoRootDirectory:
                    driveImage = 8;
                    break;
                case DriveType.Unknown:
                    driveImage = 8;
                    break;
                default:
                    driveImage = 2;
                    break;
            }
            TreeNode node = new TreeNode(drive.Substring(0, 1), driveImage, driveImage);
            node.Tag = drive;
            if (di.IsReady == true)
                 node.Nodes.Add("...");
            treeView1.Nodes.Add(node);          
        }
        foreach (TreeNode node in treeView1.Nodes)
        {
            node.Checked = true;
        }
    }
        
    private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());
                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 0, 1);
                        node.Checked = true;
                        try
                        {
                            node.Tag = dir;
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0).Checked = node.Checked;
                        }
                        catch (UnauthorizedAccessException)
                        {
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        }
                        finally
                        {
                            node.Checked = e.Node.Checked;
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }              
    }
    private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
    {
        button1.Enabled = false;
        TreeNode node = e.Node;
        bool is_checked = node.Checked;
        foreach (TreeNode childNode in e.Node.Nodes)
        {
            childNode.Checked = e.Node.Checked;
        }
        treeView1.SelectedNode = node;
     }
