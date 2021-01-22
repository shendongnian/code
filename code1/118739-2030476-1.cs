    public class comment
    {
        public string text { get; set; }
        public DateTime commentDate { get; set; }
    }
    
    XmlSerializer serializer = new XmlSerializer(typeof(comment));
    comment comment = new comment { text = "test", commentDate = DateTime.Now };
    using (MemoryStream stream = new MemoryStream())
    using (StreamReader reader = new StreamReader(stream))
    {
        serializer.Serialize(stream, comment);
        stream.Position = 0;
        Console.WriteLine(reader.ReadToEnd());
    }
