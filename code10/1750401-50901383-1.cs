    public QuestionCollection autoparsexml(string xml)
    {
        //create the serializer
        XmlSerializer serializer = new XmlSerializer(typeof(QuestionCollection));
        //convert the string into a memory stream
        MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
        //deserialize the stream into a c# object
        QuestionCollection resultingMessage = (QuestionCollection)serializer.Deserialize(memStream);
    }
    public class QuestionCollection
    {
        public List<Question> Questions { get; set; }
    }
