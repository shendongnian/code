    //Initialize your arrays here
    byte[] array1 = new byte[0];
    byte[] array2 = new byte[0];
    
    Assert.AreEqual(System.Convert.ToBase64String(array1),
                    System.Convert.ToBase64String(array2));
