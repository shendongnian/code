            XmlDocument xmlResponse = new XmlDocument();
        xmlResponse.LoadXml(
            "<LIST>" +
                "<ITEM NUMBER='3' TEXT='C'/>" +
                "<ITEM NUMBER='2' TEXT='B'/>" +
                "<ITEM NUMBER='1' TEXT='A'/>" +
            "</LIST>");
        XPathNavigator nav = xmlResponse.CreateNavigator();
        XPathExpression exp = nav.Compile("LIST/ITEM");
        exp.AddSort("@NUMBER", XmlSortOrder.Descending, XmlCaseOrder.None, "", XmlDataType.Number);
        XmlNode item = nav.SelectSingleNode(exp).UnderlyingObject as XmlNode;
        Console.WriteLine(item.OuterXml);
