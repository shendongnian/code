    bool ArEqual(Cursor cur1, Cursor cur2)
    {
        byte[] bytes1, bytes2;
        using (var ico = Icon.FromHandle(cur1.Handle))
        using (var fs = new MemoryStream())
        {
            ico.Save(fs);
            bytes1 = fs.ToArray();
        }
        using (var ico = Icon.FromHandle(cur2.Handle))
        using (var fs = new MemoryStream())
        {
            ico.Save(fs);
            bytes2 = fs.ToArray();
        }
        return bytes1.SequenceEqual(bytes2);
    }
