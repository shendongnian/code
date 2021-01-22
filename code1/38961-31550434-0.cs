        public class BrowserMenuRenderer : ToolStripProfessionalRenderer
    {
        public BrowserMenuRenderer() : base(new BrowserColors()) {}
    }
    public class BrowserColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(30, 30, 30); }
        }
        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(30, 30, 30); }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(30, 30, 30); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(30, 30, 30); }
        }
    }
