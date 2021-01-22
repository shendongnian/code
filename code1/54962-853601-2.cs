    class TrivialStringEncoder
    {
        private readonly XmlSerializer ser = new XmlSerializer(typeof(string[]));
        public string Encode(IEnumerable<string> input)
        {
            using (var s = new StringWriter())
            {
                ser.Serialize(s, input.ToArray());
                return s.ToString();
            }		
        }
	
        public IEnumerable<string> Decode(string input)
        {
            using (var s = new StringReader(input))
            {
                return (string[])ser.Deserialize(s);			
            }		
        }
        public static void Main(string[] args)
        {
            var encoded = Encode(args);
            Console.WriteLine(encoded);
            var decoded = Decode(encoded);
            foreach(var x in decoded)
                Console.WriteLine(x);
        }
    }
