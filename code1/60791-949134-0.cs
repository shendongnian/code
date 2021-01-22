            string txt = "some <b>bolded</b> text";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<xml><foo/></xml>");
            XmlElement foo = (XmlElement)doc.SelectSingleNode("//foo");
            // text: <foo>some &lt;b&gt;bolded&lt;/b&gt; text</foo>
            foo.RemoveAll();
            foo.InnerText = txt;
            Console.WriteLine(foo.OuterXml);
            // xml: <foo>some <b>bolded</b> text</foo>
            foo.RemoveAll();
            foo.InnerXml = txt;
            Console.WriteLine(foo.OuterXml);
            // CDATA: <foo><![CDATA[some <b>bolded</b> text]]></foo>
            foo.RemoveAll();
            foo.AppendChild(doc.CreateCDataSection(txt));
            Console.WriteLine(foo.OuterXml);
            
