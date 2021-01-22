    string data = @"uno, dos, tr\,es";
    string[] items = data.Split(','); // {"uno", " dos", @"tr\", "es"}
    List<string> realitems = new List<string>();
    for (int i=items.Length-1; i >= 0; i--)
    {
        string item = items[i];
        if (realitems.Count == 0) { realitems.Insert(0, item); }
        else
        {
            if (item[item.Length - 1] == '\\') { realitems[0] = item + "," + realitems[0]; }
            else { realitems.Insert(0, item); }
        }
    }
    // Should end up with {"uno", " dos", "tr,es"}
