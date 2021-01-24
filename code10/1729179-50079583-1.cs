    using (var ms = new System.IO.MemoryStream(Convert.FromBase64String(encoded)))
    {
        object ob = Deserialize(ms);
        Console.WriteLine(ob.ToString());
    }
