        private void Form1_Load(object sender, EventArgs e)
        {
            var paths = new List<string>
                            {
                                @"C:\WINDOWS\AppPatch\MUI\040C",
                                @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727",
                                @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\MUI",
                                @"C:\WINDOWS\addins",
                                @"C:\WINDOWS\AppPatch",
                                @"C:\WINDOWS\AppPatch\MUI",
                                @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\MUI\0409"
                            };
            treeView1.PathSeparator = @"\";
            PopulateTreeView(treeView1, paths, '\\');
        }
        private static void PopulateTreeView(TreeView treeView, IEnumerable<string> paths, char pathSeparator)
        {
            TreeNode lastNode = null;
            string subPathAgg;
            foreach (string path in paths)
            {
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;
                    TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode == null)
                            lastNode = treeView.Nodes.Add(subPathAgg, subPath);
                        else
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
            }
        }
