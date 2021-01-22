    using (Form form = new Form())
    using (ListView lv = new ListView())
    {
        lv.Dock = DockStyle.Fill;
        lv.View = View.Details;
        lv.Columns.Add("Version");
        lv.Items.Add(version);
        form.Controls.Add(lv);
        form.ShowDialog();
    }
