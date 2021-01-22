    listBox1.BeginUpdate();
    try {
      for(int i = listBox1.Items.Count - 1; i >= 0 ; i--) {
        // do with listBox1.Items[i]
    
        listBox1.Items.RemoveAt(i);
      }
    } finally {
      listBox1.EndUpdate();
    }
