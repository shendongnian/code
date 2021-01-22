    public class MenuExtractionUtility
        {
            public void MenuTraverse(MainMenu mainMenu, TreeView treeView)
            {
                TreeNode ultimateMainNode = new TreeNode();
                ultimateMainNode.Text = "Root";
    
                TreeNode mainNode = null;
    
                foreach (MenuItem mi in mainMenu.MenuItems)
                {
                    if (mi != null && mi.Text != "")
                    {
                        mainNode = null;
    
                        if (mi.MenuItems.Count <= 0)
                        {
                            mainNode = new TreeNode();
                            mainNode.Text = mi.Text;
                        }
                        else if (mi.MenuItems.Count > 0)
                        {
                            mainNode = MenuItemTraverse(mi);
                        }
    
                        ultimateMainNode.Nodes.Add(mainNode);
                    }
                }
    
                treeView.Nodes.Add(ultimateMainNode);
            }
    
            private TreeNode MenuItemTraverse(MenuItem menuItem)
            {
                TreeNode treeNode = new TreeNode();
                System.Diagnostics.Debug.Write(menuItem.Text+",");
                treeNode.Text = menuItem.Text;
    
                foreach (MenuItem mi in menuItem.MenuItems)
                {
                    if (mi != null && mi.Text != "")
                    {
                        TreeNode tr = MenuItemTraverse(mi);
    
                        if (tr != null && tr.Text != "")
                        {
                            treeNode.Nodes.Add(tr);
                        }
                    }
                }
    
                return treeNode;
            }
