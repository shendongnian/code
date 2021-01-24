    using (Pkcs11 pkcs11 = new Pkcs11("cryptoki.dll", true))
                {
                    // Get list of available slots with token present
                    List<Slot> slots = pkcs11.GetSlotList(true);
    
                    // Find first slot with token present
                    Slot slot = slots[0];
    
                    // Open RO session
                    using (Session session = slot.OpenSession(true))
                    {
                        session.Login(CKU.CKU_USER, "userPin");
    
                        // Prepare attribute template that defines search criteria
                        List<ObjectAttribute> objectAttributes = new List<ObjectAttribute>();
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_LABEL, "TestKey"));
    
                        // Initialize searching
                        session.FindObjectsInit(objectAttributes);
    
                        // Get search results
                        List<ObjectHandle> foundObjects = session.FindObjects(2);
    
                        // Terminate searching
                        session.FindObjectsFinal();
    
                        ObjectHandle objectHandle = foundObjects[0];
    
                        byte[] iv = Encoding.UTF8.GetBytes("00000000");
                        byte[] inputData = Encoding.UTF8.GetBytes("data to encrypt.");
    
                        Mechanism mechanism = new Mechanism(CKM.CKM_DES3_CBC, iv);
    
                        byte[] result = session.Encrypt(mechanism, objectHandle, inputData);
    
                        Console.WriteLine(Convert.ToBase64String(result)); 
                    }
                }
