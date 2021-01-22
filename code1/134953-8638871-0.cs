    public static string Transform(string xmlString)
            {
                string output = String.Empty;
                try
                {
                    // Load an XML string into the XPathDocument.
                    StringReader rdr = new StringReader(xmlString);
                    XPathDocument myXPathDoc = new XPathDocument(rdr);
    
                    var myXslTrans = new XslTransform();
                    //load the Xsl 
                    myXslTrans.Load("XSLTFile.xslt");
                    //create the output stream
                    StringWriter sw = new StringWriter();
                    XmlWriter xwo = XmlWriter.Create(sw);
                    //do the actual transform of Xml
                    myXslTrans.Transform(myXPathDoc, null, xwo);
                    output = sw.ToString();
                    xwo.Close();
    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: {0}", e.ToString());
                }
                return output;
            }
