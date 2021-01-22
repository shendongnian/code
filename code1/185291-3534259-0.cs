    private int _checkedCheckboxes;
    void AddCheckBox()
    {
        if (_checkedCheckBoxes++ == 1) RunButton.Enabled = true;
    }
    void RemoveCheckBox()
    {
        if (_checkedCheckBoxes-- == 0) RunButton.Enabled = false;
    }
    void TreeNode_AfterCheck(object sender, TreeViewEventArgs e) 
    {
        if (e.Node.Checked)
        {
            AddCheckBox();
            return;
        }
        RemoveCheckBox();
    }
