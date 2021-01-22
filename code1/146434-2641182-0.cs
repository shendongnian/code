    protected void btnAppend_Click(object sender, EventArgs e) {
        System.Diagnostics.Trace.WriteLine("DEBUGGING! -> Page.Request.PhysicalPath = "
            + Page.Request.PhysicalPath);
        Label lb3 = new Label();
        lb3.Text = Page.Request.PhysicalPath;
        string fullpath2 = Page.Request.PhysicalPath;
        System.Diagnostics.Trace.WriteLine("DEBUGGING! ->  fullpath2 = " + fullpath2);
    }
