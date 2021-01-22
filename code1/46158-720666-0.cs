    for (int i = 0; i < ListBox1.Items.Count; i++)
    {
       if (ListBox1.Items[i].Selected)
       {
          ListBox1.Items.RemoveAt(i)
          i--;
       }
    }
