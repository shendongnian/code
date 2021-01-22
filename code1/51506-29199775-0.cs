    private void showCheckBoxToolTip(object sender, MouseEventArgs e)
    {
        if (toolTipIndex != this.checkedListBox.IndexFromPoint(e.Location))
        {
            toolTipIndex = checkedListBox.IndexFromPoint(checkedListBox.PointToClient(MousePosition));
            if (toolTipIndex > -1)
            {
                toolTip1.SetToolTip(checkedListBox, checkedListBox.Items[toolTipIndex].ToString());
            }
        }
    }
