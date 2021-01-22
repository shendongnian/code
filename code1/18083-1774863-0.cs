    public class MyTextBox : ToolStripTextBox
    {
        ContextMenuStrip _contextMenuStrip;
        public ContextMenuStrip ContextMenuStrip
        {
            get { return _contextMenuStrip; }
            set { _contextMenuStrip = value; }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (_contextMenuStrip !=null)
                    _contextMenuStrip.Show(Parent.PointToScreen(e.Location));
            }
        }
    }
