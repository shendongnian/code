    static void WithLinqRec(Dictionary<string, string> dict)
    {
        var flats = from kvp in dict
                    let arr = kvp.Key.Split('/')
                    select new { l0 = arr[0], l1 = arr[1], l2 = arr[2], l3 = arr[3], l4 = kvp.Value };
        var q = from f in flats
                group f by f.l0 into g0
                select new
                {
                    el = g0.Key,
                    g = from f in g0
                        group f by f.l1 into g1
                        select new
                        {
                            el = g1.Key,
                            g = from f in g1
                                group f by f.l2 into g2
                                select new
                                {
                                    el = g2.Key,
                                    g = from f in g2
                                        group f by f.l3 into g3
                                        select new
                                        {
                                            el = g3.Key,
                                            g = g3.First().l4
                                        }
                                }
                        }
                };
        var sw = new StringWriter();
        var xw = new System.Xml.XmlTextWriter(sw) { Formatting = System.Xml.Formatting.Indented };
        Action<dynamic> writeNode = null;
        writeNode = (n) =>
        {
            xw.WriteStartElement(n.el);
            if (typeof(string) == n.g.GetType())
            {
                xw.WriteString(n.g);
            }
            else
            {
                foreach (var n1 in n.g)
                    writeNode(n1);
            }
            xw.WriteEndElement();
        };
        foreach (var n in q)
            writeNode(n);
        var xml = sw.ToString();
        Console.WriteLine(xml);
    }
