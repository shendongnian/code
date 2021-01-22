    // get connection to the database
    var c1= new System.Data.SqlClient.SqlConnection(connstring1);
    var da = new System.Data.SqlClient.SqlDataAdapter()
    {
        SelectCommand= new System.Data.SqlClient.SqlCommand(strSelect, c1)
    };
    DataSet ds1 = new DataSet();
    // fill the dataset with the SELECT 
    da.Fill(ds1, "Invoices");
    // write the XML for that DataSet into a zip file (split into 1mb chunks)
    using(Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
    {
        zip.MaxOutputSegmentSize = 1024*1024;
        zip.AddEntry(zipEntryName, (name,stream) => ds1.WriteXml(stream) );
        zip.Save(zipFileName);
    }
