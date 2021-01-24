    private void settB_Click(object sender, EventArgs e)
    {
        using (Form window = new Form())
        {
            qlSetting ql = new qlSetting();
            ql.Dock = DockStyle.Fill;
            window.Controls.Add(ql);
            window.ShowDialog();
        }
    }
