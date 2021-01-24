    public void filtro_TextChanged(object sender, EventArgs e)
    {
        ListViewVistas.Items.Clear();
        foreach(ListViewItem item in masterlist.Where(lvi => lvi.Text.ToLower().Contains(filtro.Text.ToLower())))
        {
            ListViewVistas.Items.Add(item);
        }
    }
