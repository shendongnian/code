    string source= @" <root>
    <NumberActa>20659</NumberActa>
    <DegreeDate>09/10/2018</DegreeDate>
    <StudentList>
        <CostsCenter>ABK015q</CostsCenter>
        <DocumentType>C.C h.</DocumentType>
        <Names>LISSET MARCELA</Names>
    </StudentList>
    <StudentList>
        <CostsCenter>ABCDE</CostsCenter>
        <DocumentType>C.C h.</DocumentType>
        <Names>MARCELA</Names>
    </StudentList>
    </root>";
    var document = new XmlDocument();
    document.LoadXml(source);
    XmlNode oldRoot = document.SelectSingleNode("root");
    XmlNode newRoot = document.CreateElement("DA");
    XmlNode second = document.CreateElement("DE");
          
    document.ReplaceChild(newRoot, oldRoot);
    newRoot.AppendChild(second);
    foreach (XmlNode childNode in oldRoot.ChildNodes)
    {
        second.AppendChild(childNode.CloneNode(true));
    }
    var result = document.InnerXml;
