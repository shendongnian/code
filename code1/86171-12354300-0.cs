    private void csv2_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataSet dsSchema = new DataSet();
            dsSchema.ReadXml(@"C:\Working\Teradata\ssis\Sample.xml");
            StringReader sreader = new StringReader(ToXml(dsSchema));
             ds.ReadXmlSchema(sreader);
             ds.ReadXml(@"C:\Working\Teradata\ssis\Sample.xml");
            ExportTableToCsvString(ds.Tables["session"], true, @"C:\Working\Teradata\ssis\op\session.csv");
            BuildDynamicTable(ds, @"C:\Working\Teradata\ssis\op\");
        }
        public string ToXml(DataSet ds)
        {
            using (var memoryStream = new MemoryStream())
            {
                using
                       (
                       TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(DataSet));
                    xmlSerializer.Serialize(streamWriter, ds);
                    return Encoding.UTF8.GetString(memoryStream.ToArray());
                }
            }
        }
