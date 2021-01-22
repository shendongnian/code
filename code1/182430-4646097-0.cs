    public partial class TextBoxContextMenuDemo : Form
    {
        ContextMenu mnuContextDefault;
        ContextMenu mnuContextAlt;
        MenuItem mnuItmAltMenuTest;
        public TextBoxContextMenuDemo()
        {
            InitializeComponent();
            InitializeAltContextMenu();
        }
        private void InitializeAltContextMenu()
        {
            mnuContextDefault = new ContextMenu();
            mnuContextDefault = this.TextBox1.ContextMenu;
            mnuItmAltMenuTest = new MenuItem();
            mnuItmAltMenuTest.Index = -1;
            mnuItmAltMenuTest.Text = "Test Menu Item";
            mnuItmAltMenuTest.Click += new System.EventHandler(this.mnuItmAltMenuTest_Click);
            mnuContextAlt = new ContextMenu();
            mnuContextAlt.MenuItems.Add(mnuItmAltMenuTest);
        }
        private void TextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if ((Control.ModifierKeys == Keys.Control))
                {
                    this.TextBox1.ContextMenu = mnuContextAlt;
                    TextBox1.ContextMenu.Show(TextBox1, new Point(e.X, e.Y));
                }
                else
                {
                    this.TextBox1.ContextMenu = mnuContextDefault;
                }
            }
        }
        private void mnuItmAltMenuTest_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("You clicked the alternate test menu item!");
        }
    }
