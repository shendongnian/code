    //
    // this handler's only responsibility is setting the correct context menu:
    //
    void lstModules_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var hitTest = lstModules.HitTest(e.Location);
            if (hitTest != null && hitTest.Item != null)
            {
                lstModules.ContextMenuStrip = mnuContext_Module;
            }
            else
            {
                lstModules.ContextMenuStrip = mnuContext_Desktop;
            }
        }
    }
