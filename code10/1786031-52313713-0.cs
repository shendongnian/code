    string text = "<Hällo World>";
    byte[] sha1;
    using (var shaM = new SHA1Managed())
    {
        sha1 = shaM.ComputeHash(Encoding.UTF8.GetBytes(text));
    }
    string encoded = Convert.ToBase64String(sha1);
    Console.Write(encoded);
