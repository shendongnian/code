    public class ProcessIcon : IDisposable
    {
        public NotifyIcon Icon { get; set; }
    
        public ProcessIcon()
        {
            Icon = new NotifyIcon();
        }
    
        public void Display()
        {
            Icon.MouseClick += OnIconMouseClick;
            Icon.Text = "Some text"
            Icon.Visible = true;
    
            // Here you insert all your items like you did with ContextMenu
            // I am not even sure what's the diffrence
            var contenxtMenu = new ContextMenuStrip();
            Icon.ContextMenuStrip = contenxtMenu;
        }
    
        public void Dispose()
        {
            Icon.Dispose();
        }
    
        private void OnIconMouseClick(object sender, MouseEventArgs e)
        {
            // Works for me
            Icon.ContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
        }
    }
