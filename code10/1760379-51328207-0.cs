            [Serializable]
        public class MyHashTable : Hashtable
        {
            private static SerializationInfo serializationInfo = null;
            protected MyHashTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
            public MyHashTable() : base()
            {
                
            }
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                base.GetObjectData(info, context);
                info.AddValue("MyVersion", 0, typeof(int));
                serializationInfo = info;
            }
            public override void OnDeserialization(object sender)
            {
                base.OnDeserialization(sender);
                var myVersion = serializationInfo.GetValue("MyVersion", typeof(string));
                Console.WriteLine($"MyVersion: {myVersion}");
            }
        }
    }
