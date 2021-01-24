    String xmlDoc = File.ReadAllText("J:\\My Drive\\XML Test Doc.gdoc");
    QBXMLRP2Lib.IRequestProcessor5 rp = new QBXMLRP2Lib.RequestProcessor3();
    rp.OpenConnection2("AppID", "AppName", QBXMLRP2Lib.QBXMLRPConnectionType.localQBD);
    string ticket = rp.BeginSession("", QBXMLRP2Lib.QBFileMode.qbFileOpenDoNotCare);
    string response = rp.ProcessRequest(ticket, xmlDoc);
