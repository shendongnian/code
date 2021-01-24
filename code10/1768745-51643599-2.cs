    using System;
    using System.IO;
    using System.Security.Cryptography;
    // ...
    using (var stream = new MemoryStream())
    using (var writer = new BinaryWriter(stream))
    using (var hash = MD5.Create())
    {
        writer.Write(day);
        writer.Write(period);
        var data = md5Hash.ComputeHash(stream.ToArray());
        var randomNumber = BitConverter.ToInt32(data);
    }
