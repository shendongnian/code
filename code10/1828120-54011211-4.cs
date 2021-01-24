    private static string MakePem(byte[] ber, string header)
    {
        StringBuilder builder = new StringBuilder("-----BEGIN ");
        builder.Append(header);
        builder.AppendLine("-----");
        string base64 = Convert.ToBase64String(ber);
        int offset = 0;
        const int LineLength = 64;
        while (offset < base64.Length)
        {
            int lineEnd = Math.Min(offset + LineLength, base64.Length);
            builder.AppendLine(base64.Substring(offset, lineEnd - offset));
            offset = lineEnd;
        }
        builder.Append("-----END ");
        builder.Append(header);
        builder.AppendLine("-----");
        return builder.ToString();
    }
