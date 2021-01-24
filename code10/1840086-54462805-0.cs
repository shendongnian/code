    // Comment out the below line and use the code below
    // CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
    ICryptoTransform Decryptor;
    MethodInfo createMethod = alg.GetType().GetMethod("_NewEncryptor", BindingFlags.NonPublic | BindingFlags.Instance);
    Decryptor = createMethod.Invoke(alg, new object[] { alg.Key, alg.Mode, alg.IV, alg.FeedbackSize, 1 }) as ICryptoTransform;
    CryptoStream cs = new CryptoStream(ms, Decryptor, CryptoStreamMode.Write);
