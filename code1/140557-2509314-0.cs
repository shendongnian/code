        // form scoped variable to hold a referece to the current UserControl
        private UserControl1 currentUserControl;
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(TabPage theTabPage in tabControl1.TabPages)
            {
                currentUserControl = new UserControl1();
                theTabPage.Margin = new Padding(0);
                theTabPage.Padding = new Padding(0);
                theTabPage.Controls.Add(currentUserControl);
                currentUserControl.Location = new Point(0,0);
                currentUserControl.Dock = DockStyle.Fill;
                currentUserControl.SendToBack();
            }
        }
