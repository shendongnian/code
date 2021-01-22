//Create The StringWriter Object
var stringWriter = new System.IO.StringWriter();
//Create XmlSerializer Object for the serialization,
RequestUpdateRBCustomerExternal is the Class of which type having all the values
var serializer = new XmlSerializer(typeof(RequestUpdateRBCustomerExternal));
//request is of type RequestUpdateRBCustomerExternal
serializer.Serialize(stringWriter, request);
SqlXml xml = new SqlXml(new XmlTextReader(stringWriter.ToString(), XmlNodeType.Document, null));
cmd.CommandText ="insert into SAPDataTracking values('"+DateTime.Now+"','"+xml.Value+"')";
