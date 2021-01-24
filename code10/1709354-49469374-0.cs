    static void WithLinqLoop(Dictionary<string, string> dict)
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
                                            val = g3.First().l4
                                        }
                                }
                        }
                };
        using (var sw = new StringWriter())
        {
            using (var xw = new System.Xml.XmlTextWriter(sw) { Formatting = System.Xml.Formatting.Indented })
            {
                foreach (var n in q)
                {
                    xw.WriteStartElement(n.el);
                    foreach (var n1 in n.g)
                    {
                        xw.WriteStartElement(n1.el);
                        foreach (var n2 in n1.g)
                        {
                            xw.WriteStartElement(n2.el);
                            foreach (var n3 in n2.g)
                            {
                                xw.WriteStartElement(n3.el);
                                xw.WriteString(n3.val);
                                xw.WriteEndElement();
                            }
                            xw.WriteEndElement();
                        }
                        xw.WriteEndElement();
                    }
                    xw.WriteEndElement();
                }
            }
            var xml = sw.ToString();
            Console.WriteLine(xml);
        }
    }
