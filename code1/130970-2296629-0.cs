    for (int i = 0; i < listBox1.Items.Count; i++)
    {
     if (!listBox1.Items[i].ToString().Contains(pc.IPAddress))
     {
      listBox1.Items.Add(pc.IPAddress);
     }
    }
