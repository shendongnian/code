    // https://en.wikipedia.org/wiki/Jenkins_hash_function
    public static uint JenkinsOneAtATimeHash(byte[] key, int start, int count)
    {
        int i = start;
        int end = start + count;
        uint hash = 0;
        while (i != end)
        {
            hash += key[i++];
            hash += hash << 10;
            hash ^= hash >> 6;
        }
        hash += hash << 3;
        hash ^= hash >> 11;
        hash += hash << 15;
        return hash;
    }
    public static byte[] ToBytes(this object obj)
    {
        using (var stream = new MemoryStream())
        {
            IFormatter formatter = new BinaryFormatter();
            // We will prepend the length of the serialized object, we leave some space
            stream.Position += sizeof(int);
            formatter.Serialize(stream, obj);
            // We append a Jenkins hash of the serialized object
            uint hash = JenkinsOneAtATimeHash(stream.GetBuffer(), 4, (int)stream.Length - sizeof(int));
            byte[] buffer = BitConverter.GetBytes(hash);
            stream.Write(buffer, 0, buffer.Length);
            // We prepend the length of the serialized object (max 2gb)
            buffer = BitConverter.GetBytes((int)stream.Length - sizeof(int) - sizeof(int));
            stream.Position = 0;
            stream.Write(buffer, 0, buffer.Length);
            return stream.ToArray();
        }
    }
    internal static T ObjectFromBytes<T>(this byte[] bytes)
    {
        if (bytes.Length < sizeof(int) + sizeof(int))
        {
            throw new Exception(string.Format("Serialized length: {0} < {1}", bytes.Length, sizeof(int) + sizeof(int)));
        }
        int length = BitConverter.ToInt32(bytes, 0);
        if (length != bytes.Length - sizeof(int) - sizeof(int))
        {
            throw new Exception(string.Format("Serialized length should be {0}, is {1} (+ sizeof(int) * 2)", length, bytes.Length - sizeof(int) - sizeof(int)));
        }
        uint hash = BitConverter.ToUInt32(bytes, bytes.Length - 4);
        uint hash2 = JenkinsOneAtATimeHash(bytes, sizeof(int), bytes.Length - sizeof(int) - sizeof(int));
        if (hash != hash2)
        {
            throw new Exception("Wrong hash!");
        }
        using (var stream = new MemoryStream(bytes, sizeof(int), bytes.Length - sizeof(int) - sizeof(int)))
        {
            IFormatter formatter = new BinaryFormatter();
            return (T)formatter.Deserialize(stream);
        }
    }
