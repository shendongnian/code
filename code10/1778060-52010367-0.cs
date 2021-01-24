    for (int i = 0; i < listBox1.Items.Count; i++)
    {
        var text = listBox1.GetItemText(listBox1.Items[i]);
        var selected = listBox1.GetSelected(i);
        MessageBox.Show(string.Format("{0}:{1}", text, selected ? "Selected" : "Not Selected"));
    }
