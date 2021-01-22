    public class DisplayForm : Form
    {
        IntPtr canvas;
        Panel displaypanel;
        public Panel DisplayPanel
        {
            get { return displaypanel; }
            set { displaypanel = value; }
        }
        public IntPtr Canvas
        {
            get { return canvas; }
            set { canvas = value; }
        }
        public DisplayForm()
        {
            displaypanel = new Panel();
            displaypanel.Dock = DockStyle.Fill;
            this.canvas = displaypanel.Handle;
            this.Controls.Add(displaypanel);
        }
    }
