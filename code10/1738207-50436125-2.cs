    // using System.Runtime.Serialization
    // using System.ServiceModel.Channels
    GetMessage body; // GetMessage is our custon serialization class
    using(var rdr = XmlReader.Create(@"your.xml"))  // or use StringReader / MemoryStream
    {
      var msg = Message.CreateMessage(rdr, Int32.MaxValue, MessageVersion.Soap11);
      body = msg.GetBody<GetMessage>();
    }
    // Now we can simply iterate over the Table
    foreach(DataRow smsrow in body.GetMessageResult.Tables["inlogSMS"].Rows)
    {
      // and smsrow has the fields in its ItemArray (accessible by its indexer)
      Console.WriteLine("Text: {0} with status {1}", smsrow["SMSText"], smsrow["Status"]);
    } 
