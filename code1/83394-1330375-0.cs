    XmlTextWriter myXW  = new XmlTextWriter(@"C:\NewXmlFile.xml", Encoding.UTF8)
    myXW.WriteStartDocument();
    myXW.WriteStartElement("Customers");
    string strConn = myConnectionString;
    OleDbConnection myConn = new OleDbConnection(strConn);
    myConn.Open();
    OleDbCommand myCMD = new OleDbCommand("select * from customers", myConn);
    OleDbDataReader myRdr = myCMD.ExecuteReader();
    while (myRdr.Read())
    {
        myXW.WriteStartElement("Customer");
        myXW.WriteAttributeString("id", myRdr.GetString(0));
        myXW.WriteElementString("companyname", myRdr.GetString(1));
        myXW.WriteElementString("contactname", myRdr.GetString(2));
        myXW.WriteElementString("contactname", myRdr.GetString(3));
        myXW.WriteElementString("address", myRdr.GetString(4));
        myXW.WriteElementString("city", myRdr.GetString(5));
        myXW.WriteElementString("country", myRdr.GetString(8));
        myXW.WriteElementString("phone", myRdr.GetString(9));
        myXW.WriteElementString("fax", myRdr.GetString(10));
        myXW.WriteEndElement();
    }
    myXW.WriteEndElement();
    myXW.WriteEndDocument();
    myXW.Flush();
    myXW.Close();
