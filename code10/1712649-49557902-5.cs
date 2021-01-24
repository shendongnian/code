    private NSDictionary BuildKeyPairAttributes(int keySize)
        {
            IList<object> keyBuilder = new List<object>();
            IList<object> valueBuilder = new List<object>();
            keyBuilder.Add(IOSConstants.Preloaded.constKSecAttrIsPermanent);
            keyBuilder.Add(IOSConstants.Preloaded.constKSecAttrApplicationTag);
            keyBuilder.Add(IOSConstants.Preloaded.constKSecAttrAccessible);
            valueBuilder.Add(NSNumber.FromBoolean(true));
            valueBuilder.Add(KeyAlias);
            valueBuilder.Add(IOSConstants.Preloaded.constKSecAccessibleWhenPasscodeSetThisDeviceOnly);
            NSDictionary privateKeyAttr = NSDictionary.FromObjectsAndKeys(valueBuilder.ToArray(), keyBuilder.ToArray());
            keyBuilder.Clear();
            valueBuilder.Clear();
            keyBuilder.Add(IOSConstants.Preloaded.constKSecAttrKeyType);
            keyBuilder.Add(IOSConstants.Preloaded.constKSecAttrKeySize);
            keyBuilder.Add(IOSConstants.Preloaded.constKSecPrivateKeyAttrs);
            valueBuilder.Add(IOSConstants.Preloaded.constKSecAttrKeyTypeRSA);
            valueBuilder.Add(keySize);
            valueBuilder.Add(privateKeyAttr);
            return NSDictionary.FromObjectsAndKeys(valueBuilder.ToArray(), keyBuilder.ToArray());
        }
    public bool CreateNewRSAKey(int keySize)
        {
            if (!Delete())
            {
                return false;
            }
            var keyGenerationAttributes = BuildKeyPairAttributes(keySize);
            var privateKey = SecKey.CreateRandomKey(keyGenerationAttributes, out NSError errCode);
            if (privateKey == null || errCode != null)
            {
                //Handle error
                return false;
            }
            return true;
        }
