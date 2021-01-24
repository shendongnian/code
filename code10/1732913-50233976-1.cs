               XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, string> items = doc.Descendants().Where(x => x.Name.LocalName == "ItemData")
                    .GroupBy(x => (string)x.Attribute("ItemOID"), y => y.Attribute("IsNull") != null ? "Null" : (string)y.Attribute("Value"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                //if above fails tgry following
                Dictionary<string, List<string>> items2 = doc.Descendants().Where(x => x.Name.LocalName == "ItemData")
                    .GroupBy(x => (string)x.Attribute("ItemOID"), y => y.Attribute("IsNull") != null ? "Null" : (string)y.Attribute("Value"))
                    .ToDictionary(x => x.Key, y => y.ToList());
                //or use two level dictionary
                Dictionary<int, Dictionary<string, string>> items3 = doc.Descendants().Where(x => x.Name.LocalName == "SubjectData")
                    .GroupBy(x => (int)x.Attribute("SubjectKey"), y => y.Descendants().Where(z => z.Name.LocalName == "ItemData")
                        .GroupBy(a => (string)a.Attribute("ItemOID"), b => b.Attribute("IsNull") != null ? "Null" : (string)b.Attribute("Value"))
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault()))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
