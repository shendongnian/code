    void MyTreeView_SelectedNodeChanged(Object sender, EventArgs e)
    {
        PanelOnTheRight.Controls.Clear();
        MyEditControl editControl = LoadControl("~/usercontrols/mycontrol.ascx");
        editControl.IdToEdit = ((TreeView)sender).SelectedNode.Value;
        PanelOnTheRight.Controls.Add(editControl);
    }
