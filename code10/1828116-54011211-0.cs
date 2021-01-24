    private const string RsaPrivateKey = "RSA PRIVATE KEY";
    private const string SubjectPublicKeyInfo = "PUBLIC KEY";
    private static byte[] PemToBer(string pem, string header)
    {
        // Technically these should include a newline at the end,
        // and either newline-or-beginning-of-data at the beginning.
        string begin = $"-----BEGIN {header}-----";
        string end = $"-----END {header}-----";
        int beginIdx = pem.IndexOf(begin);
        int base64Start = beginIdx + begin.Length;
        int endIdx = pem.IndexOf(end, base64Start);
        return Convert.FromBase64String(pem.Substring(base64Start, endIdx - base64Start));
    }
