    int count = listBox2.Items.Count;
    for (int i = count - 1; i >= 0; i--)
    {
        if (listBox2.Items[i].ToString() == " ")
        {
            listBox2.Items.RemoveAt(i);
        }
    } 
