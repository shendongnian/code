    private delegate void stringDelegate(string s);
    private void AddItem(string s)
    {
        if (list1.InvokeRequired)
        {
            stringDelegate sd = new stringDelegate(AddItem);
            this.Invoke(sd, new object[] { s });
        }
        else
        {
            list1.Items.Add(s);
        }
    }
