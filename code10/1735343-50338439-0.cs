    <script runat="server">
        protected void NodeLoad(object sender, NodeLoadEventArgs e)
        {
            // NodeID stores the local disk path ( full path ) of the selected node to expand
            string path = e.NodeID;
    
            if (!string.IsNullOrEmpty(e.NodeID))
            {
                foreach(var folder in System.IO.Directory.GetDirectories(path))
                {
                    string folderName = new System.IO.DirectoryInfo(folder).Name;
                    Node folderNode = new Node();
                    folderNode.Text = folderName;
                    folderNode.NodeID = folder;
                    e.Nodes.Add(folderNode);
                }
    
                foreach(var fileLeaf in System.IO.Directory.GetFiles(path))
                {
                    Node treeNode = new Node();
                    treeNode.Text = System.IO.Path.GetFileName(fileLeaf);
                    treeNode.NodeID = fileLeaf;
                    treeNode.Leaf = true;
                    e.Nodes.Add(treeNode);
                }
            }
        }
    </script>
