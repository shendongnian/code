     PromotionsDataContext db = new PromotionsDataContext();
                            //load sql into XML for tree view js control
                            XElement Categories =
                                new XElement("Promotions",
                                    from b in db.Promotion_GetPromotions()
                                    select new XElement("Promotion",
                                        new XElement("Category", b.CategoryName),
                                           new XElement("Client", b.ClientName),
                                           new XElement("ID", b.ID),
                                           new XElement("Title", b.Title)));
        
                            XDocument mydoc = new XDocument();
                            mydoc.Add(Categories);
        
                            try
                            {
    
                            // Load the style sheet.
                            XslCompiledTransform xslt = new XslCompiledTransform();
                            xslt.Load(@"C:\TransList.xslt");
    
                            // Execute the transform and output the results to a writer.
                            StringWriter sw = new StringWriter();
                            //XsltSettings mysettings = new XsltSettings();
                            XmlWriterSettings mysettings = new XmlWriterSettings();
    
                            xslt.Transform(mydoc.CreateReader(), null, sw);
