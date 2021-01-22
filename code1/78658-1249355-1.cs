    private bool _preventExpand = false;
    private DateTime _lastMouseDown = DateTime.Now;
    
    private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        e.Cancel = _preventExpand;
        _preventExpand  = false;
    }
    
    private void treeView1_MouseDown(object sender, MouseEventArgs e)
    {
        int delta = (int)DateTime.Now.Subtract(_lastMouseDown).TotalMilliseconds;            
        _preventExpand = (delta < SystemInformation.DoubleClickTime);
        _lastMouseDown = DateTime.Now;
    }
