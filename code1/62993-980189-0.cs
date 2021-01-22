    [ProtoContract]
    class Test {
        [ProtoMember(1)]
        public int Foo { get; set; }
        [ProtoMember(2)]
        public string Bar { get; set; }
    
        static void Main() {
            Test[] data = new Test[1000];
            for (int i = 0; i < 1000; i++) {
                data[i] = new Test { Foo = i, Bar = ":" + i.ToString() };
            }
            MemoryStream ms = new MemoryStream();
            Serializer.Serialize(ms, data);
            Console.WriteLine("Pos after writing: " + ms.Position); // 10760
            Console.WriteLine("Length: " + ms.Length); // 10760
            ms.Position = 0;
            foreach (Test foo in Serializer.DeserializeItems<Test>(ms,
                    PrefixStyle.Base128, Serializer.ListItemTag).Take(100)) {
                Console.WriteLine(foo.Foo + "\t" + foo.Bar);
            }
            Console.WriteLine("Pos after reading: " + ms.Position); // 902
    
        }
    }
