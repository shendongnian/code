    public DataTable PopulateTable(DataTable t, XmlNodeList nodes)
    {
       foreach (XmlNode n in nodes)
       {
          CreateRow(t, n);
       }
    }
    private void CreateRow(DataTable t, XmlNode n)
    {
       DataRow r = t.NewRow();
       t["foo"] = n.GetAttribute("foo");
       t["bar"] = n.GetAttribute("bar");
       t.Rows.Add(r);
    }
