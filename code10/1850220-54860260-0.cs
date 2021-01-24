    listBox1.Items.Clear();
    int startNum, endNum;
    if (int.TryParse(textBox1.Text, out startNum) && int.TryParse(textBox2.Text, out endNum))
    {
        for(int i = startNum; i <= endNum; i++)
        {
            listBox1.Items.Add(i.ToString());
        }
    }
