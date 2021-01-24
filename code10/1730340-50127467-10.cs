    listView1.View = View.Details;
    listView1.Columns.Add("name");
    listView1.Columns.Add("letter");
    listView1.Columns.Add("number");
    foreach (var item in result)
    {
        listView1.Items.Add(new ListViewItem(new string[] { item.name,item.letter,item.number.ToString()}));
    }
