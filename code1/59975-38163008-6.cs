    private void selectAll_Click(object sender, EventArgs e)
    {
        for (int val = 0; val < listBox1.Items.Count; val++)
        {
            listBox1.SetSelected(val, true);
        }
    }
