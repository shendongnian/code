    string path = @"sign.xml";
    var xDoc = new XmlDocument();
    xDoc.PreserveWhitespace = true;
    using (var fs = new FileStream(path, FileMode.Open))
    {
        xDoc.Load(fs);
    }
    // canon node list
    XmlNodeList nodeList = xDoc.SelectNodes("//Child1");
    var transform = new XmlDsigC14NTransform(true)
                        {
                            Algorithm = SignedXml.XmlDsigExcC14NTransformUrl
                        };
    var validInTypes = transform.InputTypes;
    var inputType = nodeList.GetType();
    if (!validInTypes.Any(t => t.IsAssignableFrom(inputType)))
    {
        throw new ArgumentException("Invalid Input");
    }
    transform.LoadInput(xDoc);
    var innerTransform = new XmlDsigC14NTransform();
    innerTransform.LoadInnerXml(xDoc.SelectNodes("//."));
    var ms = (MemoryStream) transform.GetOutput(typeof (Stream));
    ms.Flush();
    File.WriteAllBytes(@"child1.xml", ms.ToArray());
