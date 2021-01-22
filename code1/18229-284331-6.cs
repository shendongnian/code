        [Serializable]
        public class Foo
        {
            [XmlAttribute]
            public string Bar { get; set; }
            public string Nested { get; set; }
        }
        ...
        Foo foo = new Foo
        {
            Bar = "some & value",
            Nested = "data"
        };
        new XmlSerializer(typeof(Foo)).Serialize(Console.Out, foo);
