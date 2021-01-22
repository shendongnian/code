    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ListBox1.Items.AddRange(new Object[] { "me", "myself", "bob"});
            // set the draw mode to fixed
            ListBox1.DrawMode = DrawMode.OwnerDrawFixed;
        }
        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // draw the background
            e.DrawBackground();
            // get the font
            Font font = new Font(e.Font, (e.State & DrawItemState.Selected) == DrawItemState.Selected ? FontStyle.Bold : FontStyle.Regular);
            // draw the text
            e.Graphics.DrawString(ListBox1.Items[e.Index].ToString(), font, new SolidBrush(ListBox1.ForeColor), e.Bounds);
                e.DrawFocusRectangle();
        }
    }
