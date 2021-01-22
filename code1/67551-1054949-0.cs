    public class MenuExtractionUtility
    {
        public static void MenuItemTraverse(TreeNodeCollection parentCollection, Menu.MenuItemCollection menuItems)
        {
            foreach (MenuItem mi in menuItems)
            {
                System.Diagnostics.Debug.WriteLine(mi.Text);
                TreeNode menuItemNode = parentCollection.Add(mi.Text);
                if (mi.MenuItems.Count > 0)
                {
                    MenuItemTraverse(menuItemNode.Nodes, mi.MenuItems);
                }
            }
        }
    }
