    static void WithGroupByManyRec(Dictionary<string, string> dict)
    {
        var flats = from kvp in dict
                    let arr = kvp.Key.Split('/')
                    select new { l0 = arr[0], l1 = arr[1], l2 = arr[2], l3 = arr[3], l4 = kvp.Value };
        var grouped = flats.GroupByMany(f => f.l0, f => f.l1, f => f.l2, f => f.l3);
        var sw = new StringWriter();
        var xw = new System.Xml.XmlTextWriter(sw) { Formatting = System.Xml.Formatting.Indented };
        Action<GroupResult> writeNode = null;
        writeNode = (res) =>
        {
            xw.WriteStartElement(res.Key.ToString());
            if (res.SubGroups == null)
            {
                foreach (dynamic v in res.Items)
                {
                    xw.WriteString(v.l4.ToString());
                }
            }
            else
            {
                foreach (var n1 in res.SubGroups)
                    writeNode(n1);
            }
            xw.WriteEndElement();
        };
        foreach (var n in grouped)
            writeNode(n);
        var xml = sw.ToString();
        Console.WriteLine(xml);
    }
