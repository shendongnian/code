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
        // the following may be adapted to whatever criterion shall be used
        // to identify a record
        var id2 = row2.Element("InternalCode").Value;
    	var row = employees.Elements("row").FirstOrDefault(r => r.Element("InternalCode").Value == id2))
        if (row == null)
        {
            // row not found in doc, so add it
    		employees.Add(row2);
        }
        else
        {
            // row found; maybe update it, e.g.
            var nameElement2 = row2.Element("Name");
            if (nameElement2 != null)
            {
                var nameElement = row.Element("Name");
                if (nameElement == null)
                    nameElement = nameElement2;
                else
                    nameElement.Value = nameElement2.Value;
            }
        }
    }
