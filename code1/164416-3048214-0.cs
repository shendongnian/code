    private void CascadeToolStripMenuItem_Click(object sender, EventArgs e) {
            //LayoutMdi(MdiLayout.Cascade);
            Rectangle bounding = this.splitContainer1.Panel1.DisplayRectangle;
            Point nextFormLocation = bounding.Location;
            foreach (Control c in this.splitContainer1.Panel1.Controls) {
                if (!c.Visible) {
                    continue;
                }
                nextFormLocation.Offset(c.Margin.Left, c.Margin.Top);
                c.Location = nextFormLocation;
                c.BringToFront();
                if (c.AutoSize) {
                    c.Size = c.GetPreferredSize(bounding.Size);
                }
                nextFormLocation.X = bounding.X + 20;
                nextFormLocation.Y = bounding.Y + 20;
            }
        }
