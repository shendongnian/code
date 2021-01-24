    using (StreamReader file = File.OpenText(@"C:\Users\user\Desktop\assign.json"))
    {
        JsonSerializer serializer = new JsonSerializer();
        IEnumerable<AssgnData> movie2 = (IEnumerable<AssgnData>)serializer.Deserialize(file, typeof(IEnumerable<AssgnData>));
    }
