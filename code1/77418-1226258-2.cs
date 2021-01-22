    CheckedListBox cb = new CheckedListBox();
    for (var i = 1; i < 11; i++)
      cb.Items.Add("Item " + i, i % 3 == 0);
    
    string fmt = RHelper.FormatQuery(cb);
    Console.WriteLine(fmt);
    Console.ReadLine();
