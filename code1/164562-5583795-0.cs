    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    string dtdLink = "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd";
                    string dtdDef = "-//W3C//DTD XHTML 1.0 Transitional//EN";
        
                    // Create an xml document
                    XmlDocument htmlDoc = new XmlDocument();
                    /// Set the XmlResolver property to null to prevent the docType below from throwing exceptions
                    htmlDoc.XmlResolver = null;
        
                    try
                    {
                        // Create the doc type and append it to this document.
                        XmlDocumentType docType = htmlDoc.CreateDocumentType("html", dtdDef, dtdLink, null);
                        htmlDoc.AppendChild(docType);
        
                        // Write the root node in the xhtml namespace.
                        using (XmlWriter writer = htmlDoc.CreateNavigator().AppendChild())
                        {
                            writer.WriteStartElement("html", "http://www.w3.org/1999/xhtml");
                            // Continue the document if you'd like.
                            writer.WriteEndElement();
                        }
                    }
                    catch { }
                    
                    // Display the document on the console out
                    htmlDoc.Save(Console.Out);
        
                    Console.WriteLine();
                    Console.WriteLine("Press Any Key to exit");
                    Console.ReadKey();
                }
            }
        }
