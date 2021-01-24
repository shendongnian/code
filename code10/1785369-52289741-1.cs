    string mathMLResult = @"<math xmlns='bla'>
                                <SnippetCode>
                                  testcode1
                                </SnippetCode>
                            </math>";
    
    XDocument xmld = XDocument.Parse(mathMLResult);
    XNamespace bla = "bla";
    var mathItem = xmld.Element(bla + "math");
    var SnippetCodeItem = mathItem.Element(bla + "SnippetCode");
