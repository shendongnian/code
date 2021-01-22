        static void Main()
        {
            MyData data = new MyData();
            data.Id = 123;
            // something we know only by field id...
            Extensible.AppendValue<string>(data, 27, "my name");
            string myName = Extensible.GetValue<string>(data, 27);
            // this should be OK too (i.e. if we loaded it into something that
            // *did* understand that 27 means Name)
            MyKnownData known = Serializer.ChangeType<MyData, MyKnownData>(data);
            Console.WriteLine(known.Id);
            Console.WriteLine(known.Name);
        }
        [ProtoContract]
        class MyData : Extensible
        {
            [ProtoMember(1)]
            public int Id { get; set; }
        }
        [ProtoContract]
        class MyKnownData
        {
            [ProtoMember(1)]
            public int Id { get; set; }
            [ProtoMember(27)]
            public string Name{ get; set; }
        }
