    class Program
    {
        static void Main(string[] args)
        {
            var xdocument = XDocument.Load(@"c:\temp\sta01\test.xml");
            var xmlns = "http:...";
            var missionBlock = xdocument.Root;
            foreach (
                var acColor 
                in missionBlock
                    .Elements(XName.Get("ActiveBullsEye", xmlns))
                    .Elements(XName.Get("ActiveFlightPlan", xmlns))
                    .Elements(XName.Get("Aircraft", xmlns))
                    .Elements(XName.Get("ACColor", xmlns)))
            {
                var channel = acColor.Element(XName.Get("A", xmlns));
                Console.WriteLine($"A: {channel.Value}");
            }
            Console.ReadLine();
        }
    }
