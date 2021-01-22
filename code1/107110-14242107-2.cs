    private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) 
    {
        if ((e.ColumnIndex == 0))
        {
            CheckBox cck = new CheckBox();
            // With...
            Text = "";
            Visible = true;
            listView1.SuspendLayout();
            e.DrawBackground();
            cck.BackColor = Color.Transparent;
            cck.UseVisualStyleBackColor = true;
            
            cck.SetBounds(e.Bounds.X, e.Bounds.Y, cck.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width, cck.GetPreferredSize(new Size(e.Bounds.Width, e.Bounds.Height)).Width);
            cck.Size = new Size((cck.GetPreferredSize(new Size((e.Bounds.Width - 1), e.Bounds.Height)).Width + 1), e.Bounds.Height);
            cck.Location = new Point(3, 0);
            listView1.Controls.Add(cck);
            cck.Show();
            cck.BringToFront();
            e.DrawText((TextFormatFlags.VerticalCenter | TextFormatFlags.Left));
            cck.Click += new EventHandler(Bink);
            listView1.ResumeLayout(true);
        }
        else
        {
            e.DrawDefault = true;
        }
    }
    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        e.DrawDefault = true;
    }
    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        e.DrawDefault = true;
    }
    private void Bink(object sender, System.EventArgs e)
    {
        CheckBox test = sender as CheckBox;
        for (int i=0;i < listView1.Items.Count; i++)
        {     
            listView1.Items[i].Checked = test.Checked;
        }
    }
