    // Adds to menu
        public void addMenuToList(int menuVal, string menuTxt, int depth, bool hasChildren)
        {
            for (int i = 0; i < depth; i++)
            {
                menuTxt = "&nbsp;" + menuTxt;
            }
            if (hasChildren) { menuTxt = " + " + menuTxt; }
    
            ListItem newItem = new ListItem(menuVal.ToString(), menuTxt);
            parent.Items.Add(newItem);
        }
