    public static void Main()
        {
            XmlSerializer xs = new XmlSerializer(typeof(RssFeedModel));
            XmlTextReader reader = new XmlTextReader(@"D:/test.xml");
            RssFeedModel rssFeedModel = (RssFeedModel)xs.Deserialize(reader);
           
            Console.WriteLine(rssFeedModel.entry.FirstOrDefault()?.content.text);
            Console.ReadKey();
        }
