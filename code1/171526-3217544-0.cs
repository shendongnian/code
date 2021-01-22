    const string xml = 
        @"<xml>
            <country>
                <states>
                    <state>arkansas</state>
                    <state>california</state>
                    <state>virginia</state>
                </states>
            </country>
        </xml>";
    XDocument doc = XDocument.Parse(xml);
    doc.XPathSelectElements("//xml/country/states/state[.='arkansas']").ToList()
       .ForEach(el => el.Remove());;
    Console.WriteLine(doc.ToString());
    Console.ReadKey(true);
