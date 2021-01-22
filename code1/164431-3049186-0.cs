    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Id = 12345,
                Name = "Fred",
                Address = new Address
                {
                    Line1 = "Flat 1",
                    Line2 = "The Meadows"
                }
            };
            object value;
            using (Stream stream = new MemoryStream())
            {
                Send<Person>(stream, person);
                stream.Position = 0;
                value = Read(stream);
                person = value as Person;
            }
        }
        static void Send<T>(Stream stream, T value)
        {
            Header header = new Header()
            {
                Guid = Guid.NewGuid(),
                Type = typeof(T)
            };
            Serializer.SerializeWithLengthPrefix<Header>(stream, header, PrefixStyle.Base128);
            Serializer.SerializeWithLengthPrefix<T>(stream, value, PrefixStyle.Base128);
        }
        static object Read(Stream stream)
        {
            Header header;
            header = Serializer.DeserializeWithLengthPrefix<Header>
                (stream, PrefixStyle.Base128);
            MethodInfo m = typeof(Serializer).GetMethod("DeserializeWithLengthPrefix",
                new Type[] {typeof(Stream), typeof(PrefixStyle)}).MakeGenericMethod(header.Type);
            Object value = m.Invoke(null, new object[] {stream, PrefixStyle.Base128} );
            return value;
        }
    }
    [ProtoContract]
    class Header
    {
        public Header() { }
        [ProtoMember(1, IsRequired = true)]
        public Guid Guid { get; set; }
        [ProtoIgnore]
        public Type Type { get; set; }
        [ProtoMember(2, IsRequired = true)]
        public string TypeName
        {
            get { return this.Type.FullName; }
            set { this.Type = Type.GetType(value); }
        }
    }
    [ProtoContract]
    class Person {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public Address Address { get; set; }
    }
    [ProtoContract]
    class Address {
        [ProtoMember(1)]
        public string Line1 { get; set; }
        [ProtoMember(2)]
        public string Line2 { get; set; }
    }
