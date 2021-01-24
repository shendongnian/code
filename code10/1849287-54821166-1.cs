    class Program
    {
        public static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"Path to your xml file");
            var result = (from t in doc.Descendants("test-case")
                          from f in t.Descendants("failure")
                          select new
                          {
                              Result = t.Attribute("result").Value,
                              Failure_Message = f.Element("message") != null ? f.Element("message").Value : ""
                          }).ToList();
            //---------------Print the result------------------
            foreach (var item in result)
            {
                Console.WriteLine("Result: " + item.Result);
                Console.WriteLine("Message: " + item.Failure_Message);
            }
            Console.ReadLine();
        }
