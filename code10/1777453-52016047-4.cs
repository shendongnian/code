    Provides 
    // События TreeView/ Происходит после выбора узла дерева.
            private void TreeView1_AfterSelect(Object sender, TreeViewEventArgs e)
            {
                panel1.Controls.Clear();
     
                GridUserControl GridUsCont = new GridUserControl(????);
     
                panel1.Controls.Add(GridUsCont);
     
            }
  
