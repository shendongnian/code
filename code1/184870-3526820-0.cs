    userInstance.GetType().GetProperty("Id").SetValue(userInstance, Guid.NewGuid(), null);
    userInstance.GetType().GetProperty("Username").SetValue(userInstance, "Test1", null);
    userInstance.GetType().GetProperty("Password").SetValue(userInstance, "Test2", null);
    MemoryStream stream = new MemoryStream();
    DataContractSerializer ser = new DataContractSerializer(userInstance.GetType());
    ser.WriteObject(stream, userInstance);
    stream.Seek(0, SeekOrigin.Begin);
    object reSerialized = ser.ReadObject(stream);
    foreach (var property in reSerialized.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
        Console.WriteLine("{0}: {1}", property.Name, property.GetValue(reSerialized, null));
