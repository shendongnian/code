    class Program
    {
        static void Main(string[] args)
        {
            var blah =  new System.IO.StringReader(sourceDoc);
            var reader = System.Xml.XmlReader.Create(blah);
            StringBuilder result = new StringBuilder();
            while (reader.Read())
            {
                result.Append( reader.Value);
            }
            Console.WriteLine(result);
        }
        static string sourceDoc = "<html><body><p>this is a paragraph</p><p>another paragraph</p></body></html>";
    }
