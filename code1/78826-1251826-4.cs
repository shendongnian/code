    public partial class ChildForm : Form
    {
        public ChildForm(Form owner)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            int x = owner.Location.X + owner.Width / 2 - this.Width / 2;
            int y = owner.Location.Y + owner.Height / 2 - this.Height / 2;
            this.DesktopLocation = new Point(x, y);
        }
    }
