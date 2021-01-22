            var o2= new MyTypeWithNamespaces { ..intializers.. };
            var builder = new System.Text.StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent= true };
            using ( XmlWriter innerWriter = XmlWriter.Create(builder, settings))
                using ( XmlWriter writer = new NamespaceSupressingXmlWriter(innerWriter))
                {
                    s2.Serialize(writer, o2, ns2);
                }            
            Console.WriteLine("{0}",builder.ToString());
