    var today = new DateTime(2018, 9, 18, 10, 59, 00);
    var bytes = BitConverter.GetBytes(today.Ticks);
    Array.Resize(ref bytes, 16);
    var guid = new Guid(bytes);
    Console.WriteLine(guid); //bd02b200-1d55-08d6-0000-000000000000
