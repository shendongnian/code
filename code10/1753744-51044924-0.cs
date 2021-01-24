    var list = new List<string> { "1", "2", "3", "4" };
    var count = list.Count;
    listView1.BeginUpdate();
    for (var i = 0; i < count / 2; i++)
        listView1.Items.Add(list[i]).SubItems.Add(list[count / 2 + i]);
    listView1.EndUpdate();
