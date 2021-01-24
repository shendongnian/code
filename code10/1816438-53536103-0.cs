    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person1
            {
                Id = 12345,
                Name = "Fred",
                Address = new Address
                {
                    Line1 = "Flat 1",
                    Line2 = "The Meadows"
                }
            };
            //
            byte[] arr = Serialize(person);
            Person2 newPerson = Deserialize(arr);
            /*
            using (var file = File.Create("person.bin"))
            {
                Serializer.Serialize(file, person);
            }
            //
            Person newPerson;
            using (var file = File.OpenRead("person.bin"))
            {
                newPerson = Serializer.Deserialize<Person>(file);
            }
            */
        }
        public static byte[] Serialize(Person1 person)
        {
            byte[] result;
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, person);
                result = stream.ToArray();
            }
            return result;
        }
        public static Person2 Deserialize(byte[] tData)
        {
            using (var ms = new MemoryStream(tData))
            {
                return Serializer.Deserialize<Person2>(ms);
            }
        }
    }
    [ProtoContract]
    class Person1
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public Address Address { get; set; }
    }
    [ProtoContract]
    class Address
    {
        [ProtoMember(1)]
        public string Line1 { get; set; }
        [ProtoMember(2)]
        public string Line2 { get; set; }
    }
    [ProtoContract]
    class Person2
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public Address Address { get; set; }
    }
