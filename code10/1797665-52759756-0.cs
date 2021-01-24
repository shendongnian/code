    private DataTable LoadDataTable()
    {
        DataTable dtable = new DataTable("Prices");
        dtable.Columns.Add("startdate", typeof(string));
        dtable.Columns.Add("price", typeof(string));
        foreach(XmlElement elem in xdoc.GetElementsByTagName("Record")) 
        {
            DataRow row = dtable.NewRow();
            string startdate = elem.SelectSingleNode("COLUMN[@FormalName=\"startdate\"]").InnerText;
            string price = elem.SelectSingleNode("COLUMN[@FormalName=\"Price\"]").InnerText;
            row["startdate"] = startdate;
            row["price"] = price;
            dtable.Rows.Add(row);
        }
        return dtable;
    }
