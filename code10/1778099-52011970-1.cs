    using System;
    using System.IO;
    using System.Security.Cryptography;
    
    private string GetMD5Hash(IFormFile file)
    {
        // get stream from file then convert it to a MemoryStream
        MemoryStream stream = new MemoryStream();
        file.OpenReadStream().CopyTo(stream);
        byte[] bytes = MD5.Create().ComputeHash(stream.ToArray());
        return BitConverter.ToString(bytes).Replace("-",string.Empty).ToLower();
    }
