    string base64pubkey = "<!-- BASE64 representation of your pubkey from open ssl -->";
    RsaKeyParameters pubKey = PublicKeyFactory.CreateKey(Convert.FromBase64String(base64pubkey)) as RsaKeyParameters;
    byte[] signature = Convert.FromBase64String("<!-- BASE64 representation of your sig -->");
    byte[] message = Encoding.ASCII.GetBytes("Something that has been signed");
    ISigner sig = SignerUtilities.GetSigner("SHA1WithRSAEncryption");
    sig.Init(false, pubKey);
    sig.BlockUpdate(message, 0, message.Length);
    if (sig.VerifySignature(signature))
    {
        Console.WriteLine("all good!");
    }
