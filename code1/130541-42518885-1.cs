    string xmlReturn="
    <CMP>
    <OMP3>
        <personmenu>
            <submenuid>502</submenuid>
            <submenuid>503</submenuid>
        </personmenu>
        <accountsmenu>
            <submenuid>517</submenuid>
            <submenuid>518</submenuid>
            <submenuid>519</submenuid>
        </accountsmenu>
        <reportsmenu>
            <submenuid>522</submenuid>
            <submenuid>528</submenuid>
            <submenuid>536</submenuid>
        </reportsmenu>
    </OMP3>
    <AMP3>
        <admissionmenu>
            <submenuid>702</submenuid>
            <submenuid>703</submenuid>
        </admissionmenu>
    </AMP3>
    </CMP>"
    XmlDocument xmldoc = new XmlDocument();
    xmldoc.LoadXml(xmlReturn);
    XmlNodeList nodeListCount=xmldoc.GetElementsByTagName("submenuid");
    int nodeCount = nodeListCount.Count;
    Console.WriteLine(nodeCount);
