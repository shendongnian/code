    var tables = new Dictionary<string, Dictionary<string, string>>();
    var doc = new HtmlDocument();
    doc.Load(@"D:\(тут путь к файлу)\1.htm", Encoding.GetEncoding(1251), false);
    var tableNames = doc.DocumentNode.SelectNodes("//td[@class='pt']/a").Select(a=>a.Attributes["name"].Value);
    foreach(string name in tableNames)
    {
        var table = doc.DocumentNode.SelectSingleNode("//table[.//a[@name='" + name + "']]/following-sibling::table[1]");
        int columns = table.SelectNodes(".//tr[1]/td").Count();
        string[] keys = table.SelectNodes(".//tr/td["+(columns-1)+"]").Select(n => n.InnerText.Replace("&nbsp;"," ").Trim()).ToArray();
        string[] values = table.SelectNodes(".//tr/td["+columns+"]").Select(n => n.InnerText.Replace("&nbsp;"," ").Trim()).ToArray();
        var body = new Dictionary<string, string>();
        for (int i = 0; i < keys.Count(); i++)
        {
            string key = keys[i];
            if (body.ContainsKey(key))
                body[key] += ", " + values[i];
            else if( key!="" && values[i]!="")
                body[key] = values[i];
        }
        tables.Add(name, body);
                
    }
