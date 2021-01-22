    public void CreateTreeView()
    {
        TreeView myTreeview = new TreeView();
        myTreeview.Dock = DockStyle.Fill;
        this.Controls.Add(myTreeview);
    
        foreach (string field in MyDataBase.FieldsInMyColumn())
        {
            string[] elements = field.Split('/');
            TreeNode parentNode = null;
    
            for (int i = 0; i < elements.Length - 1; ++i)
            {                                        
                if (parentNode == null)
                {
                    bool exits = false;
                    foreach (TreeNode node in myTreeview.Nodes)
                    {
                        if (node.Text == elements[i])
                        {
                            exits = true;
                            parentNode = node;   
                        }
                    }
                    if (!exits)
                    {
                        TreeNode childNode = new TreeNode(elements[i]);
                        myTreeview.Nodes.Add(childNode);
                        parentNode = childNode;
                    }
                }
                else
                {
                    bool exits = false;
                    foreach (TreeNode node in parentNode.Nodes)
                    {
                        if (node.Text == elements[i])
                        {
                            exits = true;
                            parentNode = node;
                        }
                    }
                    if (!exits)
                    {
                        TreeNode childNode = new TreeNode(elements[i]);
                        parentNode.Nodes.Add(childNode);
                        parentNode = childNode;
                    }
                }
            }
            if (parentNode != null)
            {
               parentNode.Nodes.Add(elements[elements.Length - 1]);
            }
        }         
    }
