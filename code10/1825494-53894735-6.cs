    var dctRequest = new DCTRequest()
    {
        SchemaLocation = "http://www.dhl.com DCT-req.xsd ",
        GetQuote = new GetQuote()
        {
            Request = new Request()
            {
                ServiceHeader = new ServiceHeader()
                {
                    MessageTime = DateTime.Now,
                    MessageReference = "1234567890123456789012345678901",
                    SideID = "DDDDD",
                    Password = "XXXX"
                }
            }
        }
    };
    
    var xml = Serialize(dctRequest);
