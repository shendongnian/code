        public string Name { get; set; }
        public int Value { get; set; }
        public MyData() { }
        public MyData(SerializationInfo info, StreamingContext context)
        {
            foreach (SerializationEntry entry in info)
            {
                switch (entry.Name)
                {
                    case "Name":
                        Name = (string)entry.Value; break;
                    case "Value":
                        Value = (int)entry.Value; break;
                }
            }
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Value", Value);
        }
    }
