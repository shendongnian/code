        private static char[] charSet =
          "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        
        static rGen = new Random(); //Must share, because the clock seed only has Ticks (~10ms) resolution, yet lock has only 20-50ns delay.
        static int byteSize = 256; //Labelling convenience
        static int biasZone = byteSize - (byteSize % charSet.Length);
        static bool SlightlyMoreSecurityNeeded = true; //Configuration - needs to be true, if more security is desired and if charSet.Length is not divisible by 2^X.
        public string GenerateRandomString(int Length) //Configurable output string length
        {
          byte[] rBytes = new byte[Length]; //Do as much before and after lock as possible
          char[] rName = new char[Length];
          lock (rGen) //~20-50ns
          {
              rGen.NextBytes(rBytes);
              
              for (int i = 0; i < Length; i++)
              {
                  while (SlightlyMoreSecurityNeeded && rBytes[i] >= biasZone) //Secure against 1/5 increased bias of index[0-7] values against others. Note: Must exclude where it == biasZone (that is >=), otherwise there's still a bias on index 0.
                      rBytes[i] = rGen.NextByte();
                  rName[i] = charSet[rBytes[i] % charSet.Length];
              }
          }
          return new string(rName);
        }
