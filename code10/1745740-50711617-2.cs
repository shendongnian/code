    XDocument doc = XDocument.Load(path, LoadOptions.SetLineInfo);
    char[] invalidOrderedCharacter = new[] {'\u2022', '\u25CB' };
    char[] requiredBulletCharacters = new[] {'\u2022'};
    foreach (var list in doc.Descendants("list"))
    {
        var listType = list.Attribute("list-type")?.Value;
        foreach (var item in list.Elements("list-item"))
        {
            var lineNumber = ((IXmlLineInfo) item).LineNumber;
            var label = item.Element("label")?.Value;
            switch (listType)
            {
                case "simple":
                    if (label != null)
                    {
                        Console.WriteLine(
                            "Check line: " + lineNumber + 
                            ", <label> not supported in SIMPLE list");
                    }
                    break;
                case "ordered":
                    if (label == null || invalidOrderedCharacter.Contains(label[0]))
                    {
                        Console.WriteLine(
                            "Check line: " + lineNumber + 
                            ", <label> is either missing or has unsupported value for list-item (ORDERED list)");
                    }
                    break;
                case "bullet":
                    if (label == null || !requiredBulletCharacters.Contains(label[0]))
                    {
                        Console.WriteLine(
                            "Check line: " + lineNumber + 
                            ", <label> is either missing or has unsupported value for list-item (BULLET list)");
                    }
                    break;
            }
        }
    }
