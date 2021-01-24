     var application = new XElement("Application");
     var session1 = XElement.Parse("<session\r\nbeginTime=\"2018-05-11T10:37:30\"\r\nhalSerialNumber=\"08J-0735\"\r\ntestMode=\"Remote\"\r\nuserName=\"name1\"/>");
     var session2 = XElement.Parse("<session\r\nbeginTime=\"2018-05-11T10:37:30\"\r\nhalSerialNumber=\"08J-0735\"\r\ntestMode=\"Remote\"\r\nuserName=\"name2\"/>");
     application.Add(session1);
     application.Add(session2);
