    class Program
    {
        static void Main()
        {
            const string xml = @"
    <Thing Name=""George"">
      <Document>
        <subnode1/>
        <subnode2/>
      </Document>
    </Thing>";
            var s = new XmlSerializer(typeof(Thing));
            var thing = s.Deserialize(new StringReader(xml)) as Thing; 
            
            foreach (XmlNode node in thing.Document)
            {
                // should filter to only subnode1 and subnode2.
                if (node.Name != "" && node.Name != "#whitespace")
                {
                  Console.WriteLine(node.Name);
                }
            }
    
            Console.ReadLine();
        }
    }
