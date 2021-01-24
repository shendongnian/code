    ObservableCollection<string> source = new ObservableCollection<string>();
    private void Form1_Load(object sender, EventArgs e)
    {
        for (int i = 1; i < 10; i++)
        {
            source.Add("Item " + i);
        }
        listBox1.DataSource = source;
    }
    private void buttonMoveUp_Click(object sender, EventArgs e)
    {
        foreach (int index in listBox1.SelectedIndices)
        {
            if (index > 0) // don't move the first element upwards
            {
                source.Move(index, index - 1);
            }
        }
        listBox1.DataSource = null;
        listBox1.DataSource = source;
    }
    private void buttonMoveDown_Click(object sender, EventArgs e)
    {
        for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
        {
            int index = listBox1.SelectedIndices[i];
            if (index < source.Count-1) // don't move the last element downwards
            {
                source.Move(index, index + 1);
            }
        }            
        listBox1.DataSource = null;
        listBox1.DataSource = source;
    }
