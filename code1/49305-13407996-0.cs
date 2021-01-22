      public Option<int> IntParse(string str) {
        int num;  // mutable
        if (!int.TryParse(str, out num))
          return Option.None<int>();
        else
          return Option.Some<int>(num);
      }
