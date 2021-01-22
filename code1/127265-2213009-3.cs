    //
    // this handler's only responsibility is setting the correct context menu:
    //
    void someListView_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var hitTest = someListView.HitTest(e.Location);
            if (hitTest != null && hitTest.Item != null)
            {
                someListView.ContextMenuStrip = itemMenu;
            }
            else
            {
                someListView.ContextMenuStrip = desktopMenu;
            }
        }
    }
