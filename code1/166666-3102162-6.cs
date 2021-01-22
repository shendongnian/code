    var messageBytes = new UnicodeEncoding().GetBytes(str);
    var hashValue = new System.Security.Cryptography.SHA512Managed().
        ComputeHash(messageBytes);
    return hashValue.Aggregate<byte, string>("",
        (s, b) => s += string.Format("{0:x2}", b)
    );
