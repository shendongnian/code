    private void Form1_Load(object sender, EventArgs e) {
                treeList1.ForceInitialize();
    
                treeList1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
                treeList1.Appearance.FocusedCell.ForeColor = System.Drawing.SystemColors.HighlightText;
                treeList1.OptionsBehavior.Editable = false;
    
                treeList1.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            }
