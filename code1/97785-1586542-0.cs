    var list = new List<string>();
    foreach(string s in array)
    {
        if ((s ?? "").Contains("ack"))
        {
            list.Add(s);
        }
    }
