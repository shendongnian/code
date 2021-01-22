    private void SomeMethod()
    {
        ThreadPool.QueueUserWorkItem((state) =>
            {
                List<int> ints = new List<int>();
                for (int i = 0; i < 10000; i++)
                {
                    ints.Add(i);
                    if (i % 25 == 0)  // update the listbox on every 25th item
                    {
                        this.Invoke(
                              new Action<IEnumerable<int>>(AddItemsToList), ints);
                        ints.Clear();
                    }
                    if (ints.Count != 0)  // make sure to add any "trailing" items
                    {
                        this.Invoke(
                              new Action<IEnumerable<int>>(AddItemsToList), ints);
                    }
                }
            });
    }
    
    private void AddItemsToList(IEnumerable<int> items)
    {
        listBox1.BeginUpdate();
        foreach (var item in items)
        {
            listBox1.Items.Add(item);
        }
        listBox1.EndUpdate();
        listBox1.SetSelected(listBox1.Items.Count - 1, true); 
        listBox1.SelectedIndex = -1;
        listBox1.Update();
    }
