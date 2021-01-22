public static T DeepCopy<T>(T other)
{
    using (MemoryStream ms = new MemoryStream())
    {
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(ms, other);
        ms.Position = 0;
        return (T)formatter.Deserialize(ms);
    }
}
