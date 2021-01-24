c#
        // Create factories used by Pkcs11Interop library
        Pkcs11InteropFactories factories = new Pkcs11InteropFactories();
        // Load unmanaged PKCS#11 library
        using (IPkcs11Library pkcs11Library = factories.Pkcs11LibraryFactory.LoadPkcs11Library(factories, options.PKCS11LibraryPath, AppType.SingleThreaded))
        {
            // Find first slot with token present
            ISlot slot = pkcs11Library.GetSlotList(SlotsType.WithTokenPresent)[0];
            // Open RW session
            using (ISession session = slot.OpenSession(SessionType.ReadWrite))
            {
                // Login as normal user
                session.Login(CKU.CKU_USER, options.Pin);
                // Generate asymmetric key encryption key pair
                IObjectHandle asymKeyEncrpytionPublicKey = null;
                IObjectHandle asymKeyEncryptionPrivateKey = null;
                Helpers.GenerateKeyPair(session, out asymKeyEncrpytionPublicKey, out asymKeyEncryptionPrivateKey, "KEK");
                // Load aes key from file
                // Generate the key with the following command: "openssl rand -out aes256-forImport.key 32"
                byte[] sourceKey = File.ReadAllBytes(options.aesKeyPath);
                Console.WriteLine($"Loaded AES key: {BitConverter.ToString(sourceKey)}");
                // Specify wrapping mechanism
                IMechanism asymMechanism = session.Factories.MechanismFactory.Create(CKM.CKM_RSA_PKCS);
                // Encrypt key in file
                byte[] encryptedKey = session.Encrypt(asymMechanism, asymKeyEncrpytionPublicKey, sourceKey);
                // Define attributes for unwrapped key
                List<IObjectAttribute> objectAttributes = new List<IObjectAttribute>();
                objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_CLASS, CKO.CKO_SECRET_KEY));
                objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_KEY_TYPE, CKK.CKK_AES));
                objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_ENCRYPT, true));
                objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_DECRYPT, true));
                objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_EXTRACTABLE, options.markExtractable));
                objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_TOKEN, true));
                objectAttributes.Add(session.Factories.ObjectAttributeFactory.Create(CKA.CKA_LABEL, $"Unwrapped at {DateTime.Now}"));
                // Symmetric unwrap key
                IObjectHandle symUnwrappedKey = session.UnwrapKey(asymMechanism, asymKeyEncryptionPrivateKey, encryptedKey, objectAttributes);
            }
        }
