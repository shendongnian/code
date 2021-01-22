    private async void TestListViewForm_Load(object sender, EventArgs e)
    {     
        var function = new Func<TestListViewItemClass, ListViewItem>((TestListViewItemClass x) =>
        {
            var item = new ListViewItem();
            if (x != null)
            {
                item.Text = x.TestString;
                item.SubItems.Add(x.TestDecimal.ToString("F4"));
                item.SubItems.Add(x.TestDateTime.ToString("G"));
                item.SubItems.Add(x.TestTimeSpan.ToString());
                item.SubItems.Add(x.TestInt.ToString());
                item.Tag = x;
                return item;
            }
            return null;
        });
           PopulateListView<TestListViewItemClass>(this.listView1, function, GetItems(), progress);
     }
