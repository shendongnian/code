      [Flags]
      public enum DrugKind {
        None = 0,
        Narcotic = 1,
        Psychotropic = 1 << 1,
        // SomeOtherKind = 1 << n // where n = 2, 3, 4 etc.
      }
