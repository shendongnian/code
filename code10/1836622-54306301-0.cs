    string name = "Daniel";
    int zero = 0;
    string empty = "";
    int returnCode = 1;
    var xml = XElement.Load("EXAMPLE.xml");
    var output = xml.Element("OUTPUT");
    int nameLen = (int)(output.Element("NAME").Attribute("len"));
    int zeroLen = (int)(output.Element("ZERO").Attribute("len"));
    int emptyLen = (int)(output.Element("EMPTY").Attribute("len"));
    int returnCodeLen = (int)(output.Element("RETURNCODE").Attribute("len"));
    string result =
        name.PadRight(nameLen) +
        zero.ToString("D" + zeroLen) +
        empty.PadRight(emptyLen) +
        returnCode.ToString("D" + returnCodeLen);
    output.Value = result;
    xml.Save("result.xml");
