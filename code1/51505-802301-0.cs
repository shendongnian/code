    private void ShowToolTip()
        {
            ttIndex = checkedListBox1.IndexFromPoint(checkedListBox1.PointToClient(MousePosition));
            if (ttIndex > -1)
            {
                Point p = PointToClient(MousePosition);
                toolTip1.ToolTipTitle = "Tooltip Title";
                toolTip1.SetToolTip(checkedListBox1, checkedListBox1.Items[ttIndex].ToString());
                
            }
        }
