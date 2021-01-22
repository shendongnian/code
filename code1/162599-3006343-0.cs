        private Form frmPopup;
        private void treeView1_MouseEnter(object sender, EventArgs e) {
            timer1.Enabled = true;
            if (frmPopup == null) {
                frmPopup = new Form2();
                frmPopup.StartPosition = FormStartPosition.Manual;
                frmPopup.Location = PointToScreen(new Point(treeView1.Right + 20, treeView1.Top));
                frmPopup.FormClosed += (o, ea) => frmPopup = null;
                frmPopup.Show();
            }
        }
        private void timer1_Tick(object sender, EventArgs e) {
            Rectangle rc = treeView1.RectangleToScreen(new Rectangle(0, 0, treeView1.Width, treeView1.Height));
            if (!rc.Contains(Control.MousePosition)) {
                timer1.Enabled = false;
                if (frmPopup != null) frmPopup.Close();
            }
        }
