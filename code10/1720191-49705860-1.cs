    // String interpolation just to be simpler; no need for input variable either
    var stringToSign = $"/user/info/{nonce}/";
    // This is the step you were missing
    var signatureString = Convert.ToBase64String(Encoding.UTF8.GetBytes(stringToSign));
    byte[] secretKeyBytes = Encoding.UTF8.GetBytes(SecretKey);
    byte[] inputBytes = Encoding.UTF8.GetBytes(signatureString);
    using (var hmac = new HMACSHA256(secretKeyBytes))
    {
        byte[] hashValue = hmac.ComputeHash(inputBytes);
        return BitConverter.ToString(hashValue).Replace("-", "").ToLower();
    }
