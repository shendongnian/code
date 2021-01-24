    DataSet ds = new DataSet();
    ds.Tables.Add(dt1); // Table 1
    ds.Tables.Add(dt2); // Table 2...
    ...
    string dsXml= ds.GetXml();
    ...
    using (StreamWriter fs = new StreamWriter(xmlFile)) // XML File Path
    {
          ds.WriteXml(fs);
    }
