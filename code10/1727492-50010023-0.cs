    [XmlType(TypeName = "Lesson")]
    public class LessonOld
    {
        public LessonOld()
        {
            Students = new List<string>();
        }
        public string Name { get; set; }
        public DateTime FirstLessonDate { get; set; }
        public int DurationInMinutes { get; set; }
        public List<string> Students { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter writer = new StreamWriter(Path.Combine(@"C:\Users\Francesco\Desktop\nanovg", "Lessons-temp.xml"));
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<LessonOld>));
            xmlSerializer.Serialize(writer, new List<LessonOld> { new LessonOld() { Name = "name", DurationInMinutes = 0 } });
            writer.Close();
        }
    }
