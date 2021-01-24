    //in BuildKeyPairAttributes
    keyBuilder.Add(IOSConstants.Preloaded.constKSecAttrIsPermanent);
    keyBuilder.Add(IOSConstants.Preloaded.constKSecAttrApplicationTag);  
    //constKSecAttrAccessControl = Dlfcn.GetStringConstant(handle, "kSecAttrAccessControl");
    keyBuilder.Add(IOSConstants.Preloaded.constKSecAttrAccessControl);
    
    valueBuilder.Add(NSNumber.FromBoolean(true));
    valueBuilder.Add(KeyAlias);
    valueBuilder.Add(new SecAccessControl(SecAccessible.WhenPasscodeSetThisDeviceOnly, SecAccessControlCreateFlags.UserPresence));
    
    NSDictionary privateKeyAttr = NSDictionary.FromObjectsAndKeys(valueBuilder.ToArray(), keyBuilder.ToArray());
