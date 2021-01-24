        private void viewTextFile()
        {
            foreach(var line in File.ReadAllLines(somefilepath))
                AddLineToListView(line);
        }
        private void AddLineToListView(string line)
        {
            if (string.IsNullOrEmpty(line))
                return;
            var lvItem = new ListViewItem(line.Split(','));
            lvResult.Items.Add(lvItem);
        }
