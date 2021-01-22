    // <summary>
    // Serialize Object to XML and then read it into a DataSet:
    // </summary>
    // <param name="arrCollection">Array of object</param>
    // <returns>dataset</returns>
     
    public static DataSet ToDataSetFromArrayOfObject( this object[] arrCollection)
    {
     	DataSet ds = new DataSet();
    	try {
    		XmlSerializer serializer = new XmlSerializer(arrCollection.GetType);
    		System.IO.StringWriter sw = new System.IO.StringWriter();
    		serializer.Serialize(sw, dsCollection);
    		System.IO.StringReader reader = new System.IO.StringReader(sw.ToString());
    		ds.ReadXml(reader);
    	} catch (Exception ex) {
    		throw (new Exception("Error While Converting Array of Object to Dataset."));
    	}
    	return ds;
    }
