    var doc = XDocument.Parse(@"<Company>
        <Owner>Bob</Owner>
        <Contact>
            <address> -1 Infinite Loop </address>
            <phone>
                <LandLine>(000) 555-5555</LandLine>
                <Fax> (000) 555-5556 </Fax>
            </phone>
            <email> foo@bar.com </email>
        </Contact>
    </Company>");
    var phone = doc.Root.Element("Contact").Element("phone");
    Console.WriteLine((string)phone.Element("LandLine"));
    Console.WriteLine((string)phone.Element("Fax"));
