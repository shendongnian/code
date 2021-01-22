            string xml = @"<note>
              <title>Test Sync Note 1</title> 
              <content>
              <![CDATA[ <?xml version=""1.0"" encoding=""UTF-8""?>
               <!DOCTYPE en-note SYSTEM ""http://xml.evernote.com/pub/enml.dtd"">
            <en-note bgcolor=""#FFFFFF"">
            <div>Test Sync Note 1</div>
            <div>This i has some text in it</div>
            <div> </div>
            <div> </div>
            <div>and a second line</div>
            </en-note>
              ]]> 
              </content>
              <created>20081028T045727Z</created> 
              <updated>20081028T051346Z</updated> 
              <tag>Test</tag> 
            </note>
            ";
            XPathDocument doc = new XPathDocument(new StringReader(xml));
            XPathNavigator nav = doc.CreateNavigator();
            // Compile a standard XPath expression
            XPathExpression expr;
            expr = nav.Compile("/note/content");
            XPathNodeIterator iterator = nav.Select(expr);
            // Iterate on the node set
            try
            {
                while (iterator.MoveNext())
                {
                    //Get the XML in the CDATA
                    XPathNavigator nav2 = iterator.Current.Clone();
                    XPathDocument doc2 = new XPathDocument(new StringReader(nav2.Value.Trim()));
                    //Parse the XML in the CDATA
                    XPathNavigator nav3 = doc2.CreateNavigator();
                    expr = nav3.Compile("/en-note");
                    XPathNodeIterator iterator2 = nav3.Select(expr);
                    iterator2.MoveNext();
                    XPathNavigator nav4 = iterator2.Current.Clone();
                    //Output the value directly, does not preserve the formatting
                    Console.WriteLine("Direct Try:");
                    Console.WriteLine(nav4.Value);
                    //This works, but is ugly
                    Console.WriteLine("Ugly Try:");
                    Console.WriteLine(nav4.InnerXml.Replace("<div>","").Replace("</div>",Environment.NewLine));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
