    for(int i=0; i < listBox1.Items.Count; )
    {
        string removelistitem = "OBJECT";
        if(listBox1.Items[i].Contains(removelistitem))
             listBox1.Items.Remove(item);
        else
            ++i;
    }
