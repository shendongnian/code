    private void button1_Click(object sender, EventArgs e)
    {
        var children = MdiParent.MdiChildren.OrderBy(c => c.Index).ToList();
        for (int x = 0; x < children.Count; x++) {
            MessageBox.Show(children[x].Text);
        }
    }
