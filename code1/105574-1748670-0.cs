    [XmlRoot("clubMember")]
    public class Person
    {
        [XmlElement("memberName")]
        public string Name { get; set; }
        [XmlArray("memberPoints")]
        [XmlArrayItem("point")]
        public List<Point> ClubPoints { get; set; }
    }
    public class Point
    {
        [XmlAttribute("value")]
        public int Value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var member = new Person
            {
                Name = "Name",
                ClubPoints = new List<Point>(new[] 
                { 
                    new Point { Value = 1 }, 
                    new Point { Value = 2 }, 
                    new Point { Value = 3 } 
                })
            };
            var serializer = new XmlSerializer(member.GetType());
            serializer.Serialize(Console.Out, member);
        }
    }
