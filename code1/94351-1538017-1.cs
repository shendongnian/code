    foreach (string list in lists)
    {
            Button btn = new Button();
            btn.Click += new EventHandler(delegate { MessageBox.Show(list); });
    }
