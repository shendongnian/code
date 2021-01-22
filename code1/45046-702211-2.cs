    var binaryFormatter = new BinaryFormatter();
    comboFormat.Items.AddRange(new object[]
    { 
        new SerializingHelper
        {
            Name = "Binary",
            Serializer = binaryFormatter.Serialize
        }
        ...
    });
