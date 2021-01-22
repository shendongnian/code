            var o2= new MyTypeWithNamespaces { ..intializers.. };
            var builder = new System.Text.StringBuilder();
            using ( XmlWriter writer = new NoNamespaceXmlWriter(new System.IO.StringWriter(builder)))
            {
                s2.Serialize(writer, o2, ns2);
            }            
            Console.WriteLine("{0}",builder.ToString());
