    var query = 
        from id in this.Data.Elements("ID")                      // ID
        from item in id.Elements("item")                         // /item
        where item.Attribute("id").Value == "200"                // [@id=200]
        let dat in item.Elements("DAT").ElementAtOrDefault(1)    // /DAT[1]
        where dat != null                                        // (ensure there is an element at index 1)
        from line in dat.Elements("line").Skip(1)                // /line[position()>1]
        let data in line.Elements("data").ElementAtOrDefault(1)  // /data[1]
        where data != null                                       // (ensure there is an element at index 1)
        select data                                              // /text()
    
    StringBuilder sb = new StringBuilder();
    foreach(XElement data in query)
    {
        sb.Append(data.Value);
    }
    return sb.ToString();
