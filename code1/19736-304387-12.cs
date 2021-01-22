    foreach (string list in lists)
    {
        string tmp = list;
        Button btn = new Button();
        btn.Click += new EventHandler(delegate { MessageBox.Show(tmp); });
    }
