    using System.Security.Cryptography;
    const int numberOfNumbersNeeded = 100;
    const int numberOfBytesNeeded = 8;
    var randomGen = RandomNumberGenerator.Create();
    for (int i = 0; i < numberOfNumbersNeeded; ++i)
    {
         var bytes = new Byte[numberOfBytesNeeded];
         randomGen.GetBytes(bytes);
    }
     
