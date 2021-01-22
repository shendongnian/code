      public static void ThrowOnAnyStringNullOrEmpty(params string[] argAndNames)
      {
           for (int i = 0; i < argAndName.Length; i+=2) {
              ThrowOnStringNullOrEmpty(argAndNames[i], argAndNames[i+1]);
           }
      }
