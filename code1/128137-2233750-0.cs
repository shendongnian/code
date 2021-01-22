    Customer customerCopy;
    BinaryFormatter bf = new BinaryFormatter();
    using (MemoryStream ms = new MemoryStream())
    {
        bf.Serialize(ms, customer);
        ms.Position = 0;
        customerCopy = (Customer)bf.Deserialize(ms);
    }
