    private void tabControl_MouseUp(object sender, MouseEventArgs e)
    {
        // check if the right mouse button was pressed
        if(e.Button == MouseButtons.Right)
        {
            // iterate through all the tab pages
            for(int i = 0; i < tabControl1.TabCount; i++)
            {
                // get their rectangle area and check if it contains the mouse cursor
                Rectangle r = tabControl1.GetTabRect(i);
                if (r.Contains(e.Location))
                {
                    // show the context menu here
                    System.Diagnostics.Debug.WriteLine("TabPressed: " + i);
                 }
            }
        }
    }
