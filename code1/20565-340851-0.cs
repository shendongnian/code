            // Calling the webservice
            com.fake.exampleWebservice bs = new com.fake.exampleWebservice();
            string[] foo = bs.DummyMethod();
            // Serializing the returned object
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(foo.GetType());
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            x.Serialize(ms, foo);
            ms.Position = 0;
            // Getting rid of the annoying namespaces - optional
            System.Xml.XPath.XPathDocument doc = new System.Xml.XPath.XPathDocument(ms);
            System.Xml.Xsl.XslCompiledTransform xct = new System.Xml.Xsl.XslCompiledTransform();
            xct.Load(Server.MapPath("RemoveNamespace.xslt"));
            ms = new System.IO.MemoryStream();
            xct.Transform(doc, null, ms);
            // Outputting to client
            byte[] byteArray = ms.ToArray();
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=results.xml");
            Response.AddHeader("Content-Length", byteArray.Length.ToString());
            Response.ContentType = "text/xml";
            Response.BinaryWrite(byteArray);
            Response.End();
