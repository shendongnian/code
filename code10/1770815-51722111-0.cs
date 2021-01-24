    void refresh() //gets called by button
    {
        listBox1.Items.Clear();
        if(!String.IsNullOrEmpty(objDialog.SelectedPath) && Directory.Exists(objDialog.SelectedPath))
        {
            var files = System.IO.Directory.GetFiles(objDialog.SelectedPath, "*.*", System.IO.SearchOption.AllDirectories);
            foreach (string file in files)
            {
                // do something
            }
        }
