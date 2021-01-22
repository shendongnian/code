    private void button1_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedIndices.Count > 0)
        {
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
        }
    }
