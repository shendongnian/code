    private void listBoxNode_MouseUp(object sender, MouseEventArgs e)
        {
            int location = listBoxNode.IndexFromPoint(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                listBoxNode.SelectedIndex = location;                //Index selected
                contextMenuStrip1.Show(PointToScreen(e.Location));   //Show Menu
            }
        }
