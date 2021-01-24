    class IOSConstants
    {
        private static IOSConstants _singleton;
        public static IOSConstants Preloaded
        {
            get
            {
                if(_singleton == null)
                {
                    _singleton = new IOSConstants();
                }
                return _singleton;
            }
        }
        public readonly NSString constKSecAttrKeyType;
        public readonly NSString constKSecAttrKeySize;
        public readonly NSString constKSecAttrKeyTypeRSA;
        public readonly NSString constKSecAttrIsPermanent;
        public readonly NSString constKSecAttrApplicationTag;
        public readonly NSString constKSecPrivateKeyAttrs;
        public readonly NSString constKSecClass;
        public readonly NSString constKSecClassKey;
        public readonly NSString constKSecPaddingPKCS1;
        public readonly NSString constKSecAccessibleWhenPasscodeSetThisDeviceOnly;
        public readonly NSString constKSecAttrAccessible;
        public IOSConstants()
        {
            var handle = Dlfcn.dlopen(Constants.SecurityLibrary, 0);
            try
            {
                constKSecAttrApplicationTag = Dlfcn.GetStringConstant(handle, "kSecAttrApplicationTag");
                constKSecAttrKeyType = Dlfcn.GetStringConstant(handle, "kSecAttrKeyType");
                constKSecAttrKeyTypeRSA = Dlfcn.GetStringConstant(handle, "kSecAttrKeyTypeRSA");
                constKSecAttrKeySize = Dlfcn.GetStringConstant(handle, "kSecAttrKeySizeInBits");
                constKSecAttrIsPermanent = Dlfcn.GetStringConstant(handle, "kSecAttrIsPermanent");
                constKSecPrivateKeyAttrs = Dlfcn.GetStringConstant(handle, "kSecPrivateKeyAttrs");
                constKSecClass = Dlfcn.GetStringConstant(handle, "kSecClass");
                constKSecClassKey = Dlfcn.GetStringConstant(handle, "kSecClassKey");
                constKSecPaddingPKCS1 = Dlfcn.GetStringConstant(handle, "kSecPaddingPKCS1");
                constKSecAccessibleWhenPasscodeSetThisDeviceOnly = Dlfcn.GetStringConstant(handle, "kSecAttrAccessibleWhenPasscodeSetThisDeviceOnly");
                constKSecAttrAccessible = Dlfcn.GetStringConstant(handle, "kSecAttrAccessible");
            }
            finally
            {
                Dlfcn.dlclose(handle);
            }
        }
    }
