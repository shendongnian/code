    private class Tag
    {
        public override string ToString()
        {
            return "Tag";
        }
    }
    ListBox listBox = new ListBox();
    listBox.Items.Add(new ListViewItem { Tag = new Tag() });
    foreach (ListViewItem item in listBox.Items)
    {
        Tag tag = (Tag)item.Tag;
        Console.WriteLine(tag);
    }
