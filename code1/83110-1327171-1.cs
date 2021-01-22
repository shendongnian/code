    for (int i = ListView1.Items.Count - 1; i >= 0; i--)
    {
      if (ListView1.Items[i].Checked)
      {
        ListView2.Items.Add(ListView1.Items[i]);
        ListView1.Items.RemoveAt(i);
      }
    }
