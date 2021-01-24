    public void Suggest(List<string> words, ContextMenuStrip menu)
    {
        string suggestion = "suggestion";
        menu.Items.Cast<ToolStripItem>().Where(x => x.Tag == (object)suggestion)
            .ToList().ForEach(x => menu.Items.Remove(x));
        words.ToList().ForEach(x =>
        {
            var item = new ToolStripMenuItem(x);
            item.Tag = suggestion;
            item.Click += (s, e) => MessageBox.Show(x);
            menu.Items.Insert(0, item);
        });
    }
