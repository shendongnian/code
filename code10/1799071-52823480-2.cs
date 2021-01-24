    public void filtro_TextChanged(object sender, EventArgs e)
    {
        ListViewVistas.Items.Clear();
        ListViewVistas.Items.AddRange(masterlist.Where(lvi => lvi.Text.ToLower().Contains(filtro.Text.ToLower())).ToArray());
    }
