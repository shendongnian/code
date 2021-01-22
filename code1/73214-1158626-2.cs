      public static void ThrowOnStringNullOrEmpty(string arg, string name)
      {
          if (string.IsNullOrEmpty(arg))
            throw new ArgumentNullException(name + " can't be null");
      }
