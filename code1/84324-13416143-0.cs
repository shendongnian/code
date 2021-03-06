    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    public static string GetRandomAlphanumericString(int length)
    {
        const string alphanumericCharacters =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
            "abcdefghijklmnopqrstuvwxyz" +
            "0123456789";
        return GetRandomString(length, alphanumericCharacters);
    }
    
    public static string GetRandomString(int length, IEnumerable<char> characterSet)
    {
        if (length < 0)
            throw new ArgumentException("length must not be negative", "length");
        if (length > int.MaxValue / 4) // 500 million chars ought to be enough for anybody
            throw new ArgumentException("length is too big", "length");
        if (characterSet == null)
            throw new ArgumentNullException("characterSet");
        var characterArray = characterSet.Distinct().ToArray();
        if (characterArray.Length == 0)
            throw new ArgumentException("characters must not be empty", "characterSet");
    
        var bytes = new byte[length*4];
        new RNGCryptoServiceProvider().GetBytes(bytes);
        var result = new char[length];
        for (int i = 0; i < length; i++)
        {
            uint value = BitConverter.ToUInt32(bytes, i * 4);
            result[i] = characterArray[value % characterArray.Length];
        }
        return new string(result);
    }
