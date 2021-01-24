    var doc = XDocument.Parse(@"<ContactEmployees>
      <row>
        <Name>NAME</Name>
        <Position>Mag</Position>
        <Phone1>number</Phone1>
        <E_Mail>mail</E_Mail>
        <InternalCode>11</InternalCode>
        <Gender>gt_Undefined</Gender>
        <Active>tYES</Active>
        <FirstName>Tizio</FirstName>
        <BlockSendingMarketingContent>tNO</BlockSendingMarketingContent>
      </row>
    </ContactEmployees>");
    
    var doc2 = XDocument.Parse(@"<ContactEmployees>
          <row>
            <CardCode>1000010</CardCode>
            <Name>NAME</Name>
            <Position>Mag</Position>
            <Phone1>number</Phone1>
            <E_Mail>mail</E_Mail>
            <InternalCode>11</InternalCode>
            <Gender>gt_Undefined</Gender>
            <Active>tYES</Active>
            <BlockSendingMarketingContent>tNO</BlockSendingMarketingContent>
          </row>
          <row>
            <CardCode>1000010</CardCode>
            <Name>Prova</Name>
            <InternalCode>2703</InternalCode>
            <PlaceOfBirth>-1</PlaceOfBirth>
            <Gender>gt_Undefined</Gender>
            <Active>tYES</Active>
            <FirstName>Prova</FirstName>
            <BlockSendingMarketingContent>tNO</BlockSendingMarketingContent>
          </row>
        </ContactEmployees>");
    	
    var employees = doc.Root;
    
    var employees2 = doc2.Root;
    
    foreach (var row2 in employees2.Elements("row"))
    {
        var name2 = row2.Element("Name").Value;
    	if (!employees.Elements("row").Any(r => r.Element("Name").Value == name2))
    		employees.Add(row2);
    }
