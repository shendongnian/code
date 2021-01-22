        private Point _imageLocation = new Point(13, 5);
            private Point _imgHitArea = new Point(13, 2);
        
            private void Form1_Load(object sender, EventArgs e)
            {
                tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
        tabControl1.DrawItem += tabControl1_DrawItem;
        CloseImage = WindowsFormsApplication3.Properties.Resources.closeR;
        tabControl1.Padding = new Point(10, 3);
            }
        private void TabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
            {
                try
                {
                    Image img = new Bitmap(CloseImage);
                    Rectangle r = e.Bounds;
                    r = this.tabControl1.GetTabRect(e.Index);
                    r.Offset(2, 2);
                    Brush TitleBrush = new SolidBrush(Color.Black);
                    Font f = this.Font;
                    string title = this.tabControl1.TabPages[e.Index].Text;
    
                    e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
    
                    if (tabControl1.SelectedIndex >= 1)
                    {
                        e.Graphics.DrawImage(img, new Point(r.X + (this.tabControl1.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
                    }
                }
                catch (Exception) { }
            }
    
    
    private void TabControl1_Mouse_Click(object sender, System.Windows.Forms.DrawItemEventArgs e)
    {
    
    TabControl tc = (TabControl)sender;
    Point p = e.Location;
    int _tabWidth = 0;
    _tabWidth = this.tabControl1.GetTabRect(tc.SelectedIndex).Width - (_imgHitArea.X);
    Rectangle r = this.tabControl1.GetTabRect(tc.SelectedIndex);
    r.Offset(_tabWidth, _imgHitArea.Y);
    r.Width = 16;
    r.Height = 16;
    if (tabControl1.SelectedIndex >= 1)
    {
        if (r.Contains(p))
        {
            TabPage TabP = (TabPage)tc.TabPages[tc.SelectedIndex];
            tc.TabPages.Remove(TabP);
        }
    
    }
    }
