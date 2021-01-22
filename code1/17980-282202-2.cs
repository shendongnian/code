    public partial class Form1 : Form
    {
        class CustomToolStripMenuItem : ToolStripMenuItem
        {
            private ContextMenuStrip secondaryContextMenu;
            public ContextMenuStrip SecondaryContextMenu
            {
                get
                {
                    return secondaryContextMenu;
                }
                set
                {
                    secondaryContextMenu = value;
                }
            }
            public CustomToolStripMenuItem(string text)
                : base(text)
            { }
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (secondaryContextMenu != null)
                    {
                        secondaryContextMenu.Dispose();
                        secondaryContextMenu = null;
                    }
                }
                base.Dispose(disposing);
            }
            protected override void OnClick(EventArgs e)
            {
                if (SecondaryContextMenu == null || MouseButtons != MouseButtons.Right)
                {
                    base.OnClick(e);
                }
            }
        }
        class CustomContextMenuStrip : ContextMenuStrip
        {
            private bool secondaryContextMenuActive = false;
            private ContextMenuStrip lastShownSecondaryContextMenu = null;
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (lastShownSecondaryContextMenu != null)
                    {
                        lastShownSecondaryContextMenu.Close();
                        lastShownSecondaryContextMenu = null;
                    }
                }
                base.Dispose(disposing);
            }
            protected override void OnControlAdded(ControlEventArgs e)
            {
                e.Control.MouseClick += new MouseEventHandler(Control_MouseClick);
                base.OnControlAdded(e);
            }
            protected override void OnControlRemoved(ControlEventArgs e)
            {
                e.Control.MouseClick -= new MouseEventHandler(Control_MouseClick);
                base.OnControlRemoved(e);
            }
            private void Control_MouseClick(object sender, MouseEventArgs e)
            {
                ShowSecondaryContextMenu(e);
            }
            protected override void OnMouseClick(MouseEventArgs e)
            {
                ShowSecondaryContextMenu(e);
                base.OnMouseClick(e);
            }
            private bool ShowSecondaryContextMenu(MouseEventArgs e)
            {
                CustomToolStripMenuItem ctsm = this.GetItemAt(e.Location) as CustomToolStripMenuItem;
                if (ctsm == null || ctsm.SecondaryContextMenu == null || e.Button != MouseButtons.Right)
                {
                    return false;
                }
                lastShownSecondaryContextMenu = ctsm.SecondaryContextMenu;
                secondaryContextMenuActive = true;
                ctsm.SecondaryContextMenu.Closed += new ToolStripDropDownClosedEventHandler(SecondaryContextMenu_Closed);
                ctsm.SecondaryContextMenu.Show(Cursor.Position);
                return true;
            }
            void SecondaryContextMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
            {
                ((ContextMenuStrip)sender).Closed -= new ToolStripDropDownClosedEventHandler(SecondaryContextMenu_Closed);
                lastShownSecondaryContextMenu = null;
                secondaryContextMenuActive = false;
                Focus();
            }
            protected override void OnClosing(ToolStripDropDownClosingEventArgs e)
            {
                if (secondaryContextMenuActive)
                {
                    e.Cancel = true;
                }
                base.OnClosing(e);
            }
        }
        public Form1()
        {
            InitializeComponent();
            
            CustomToolStripMenuItem itemPrimary1 = new CustomToolStripMenuItem("item primary 1");
            itemPrimary1.SecondaryContextMenu = new ContextMenuStrip();
            itemPrimary1.SecondaryContextMenu.Items.AddRange(new ToolStripMenuItem[] { 
                new ToolStripMenuItem("item primary 1.1"),
                new ToolStripMenuItem("item primary 1.2"),
            });
            CustomToolStripMenuItem itemPrimary2 = new CustomToolStripMenuItem("item primary 2");
            itemPrimary2.DropDownItems.Add("item primary 2, sub 1");
            itemPrimary2.DropDownItems.Add("item primary 2, sub 2");
            itemPrimary2.SecondaryContextMenu = new ContextMenuStrip();
            itemPrimary2.SecondaryContextMenu.Items.AddRange(new ToolStripMenuItem[] { 
                new ToolStripMenuItem("item primary 2.1"),
                new ToolStripMenuItem("item primary 2.2"),
            });
            CustomContextMenuStrip primaryContextMenu = new CustomContextMenuStrip();
            primaryContextMenu.Items.AddRange(new ToolStripItem[]{
                itemPrimary1,
                itemPrimary2
            });
            this.ContextMenuStrip = primaryContextMenu;
        }
    }
