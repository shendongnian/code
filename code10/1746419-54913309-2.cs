    public void SigSignature(string base64String)
    {
        using (var reader = new PdfReader("PathToTemp"))
        {
            using (var fileStream = File.OpenWrite("PathToSig"))
            {
                var byteSig = Convert.FromBase64String(base64String);
                IExternalSignatureContainer external = new MfuaExternalSignatureContainer(byteSig);
                    
                MakeSignature.SignDeferred(reader, "ExistSignatureName", fileStream, external);
            }
        }
    }
    private class MfuaExternalSignatureContainer : IExternalSignatureContainer
    {
        private readonly byte[] _signedBytes;
         
        public MfuaExternalSignatureContainer(byte[] signedBytes)
        {
            _signedBytes = signedBytes;
        }
         
        public byte[] Sign(Stream data)
        {
            return _signedBytes;
        }
         
        public void ModifySigningDictionary(PdfDictionary signDic)
        {
        }
    }
