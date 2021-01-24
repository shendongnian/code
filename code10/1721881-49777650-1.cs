    private static void Main()
            {
                var root = new Root
                {
                    Elements = new[]
                    {
                        "1st element", "2nd element", "3rd element", "4th element"
                    }
                };
                var xmlString = root.GetXmlString();
                Console.WriteLine(xmlString);
    
                var deserializedRoot = Root.DeserializeXmlString(xmlString);
                foreach (var element in deserializedRoot.Elements)
                    Console.WriteLine(element);
    
                Console.ReadLine();
            }
