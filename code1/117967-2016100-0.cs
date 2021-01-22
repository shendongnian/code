            Dictionary<string, string> dic = new Dictionary<string,string>();
            foreach (XElement element in settingsDoc.Descendants("MimeType"))
            {
                string val = element.Attribute("Type").Value;
                foreach (string str in element.Attribute("Extensions").Value.Split(';'))
                    if (!dic.ContainsKey(str)) dic.Add(str, val);
            }
