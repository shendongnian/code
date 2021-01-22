    XDocument GrabSchema(
       string dataSetName,
       string sql)
    {
       var con = new SqlConnection("<<YourConnectionString>>");
       var command = new SqlCommand(sql, con);
       var sqlAdapter = new SqlDataAdapter(command);
       var dataSet = new DataSet(dataSetName);
       sqlAdapter.FillSchema(dataSet, SchemaType.Mapped);
       var stream = new MemoryStream();
       dataSet.WriteXmlSchema(stream);
       stream.Seek(0, System.IO.SeekOrigin.Begin);
       return XDocument.Load(XmlReader.Create(stream));
    }
