    public void PopulateTable(DataTable t, XPathNodeIterator iter)
    {
       foreach (XPathNavigator n in iter)
       {
          CreateRow(t, n);
       }
    }
    private void CreateRow(DataTable t, XPathNavigator n)
    {
       DataRow r = t.NewRow();
       t["foo"] = n.GetAttribute("foo", "");
       t["bar"] = n.GetAttribute("bar", "");
       t.Rows.Add(r);
    }
