        private string Transform(string styleSheet, string xmlToParse)
                {
                    XslCompiledTransform xslt = new XslCompiledTransform();
        
                    MemoryResourceResolver resolver = new MemoryResourceResolver();            
        
        
                    XmlTextReader xR = new XmlTextReader(new StringReader(styleSheet));           
                 
                    xslt.Load(xR, null, resolver);
        
                    StringWriter sw = new StringWriter();                
        
        
                    using (var inputReader = new StringReader(xmlToParse))
                    {
                        var input = new XmlTextReader(inputReader);
                        xslt.Transform(input,
                                            null,
                                            sw);
                    }
                   
                    return sw.ToString();
                    
                }     
    
        public class MemoryResourceResolver : XmlResolver
            {
              
                public override object GetEntity(Uri absoluteUri,
                  string role, Type ofObjectToReturn)
                {
                    if (absoluteUri.ToString().Contains("Common"))
                    {
                        return new MemoryStream(Encoding.UTF8.GetBytes("Xml with with common data"?? ""));
                    }
        
                    if (absoluteUri.ToString().Contains("Xhtml"))
                    {
                        return new MemoryStream(Encoding.UTF8.GetBytes("Xml with with xhtml data"?? ""));
                    }         
        
                    return "";
                }
            }
    
