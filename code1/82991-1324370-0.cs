    public int doSomeWork(string value) {
      int someValue = 0;
      if (!string.IsNullOrEmpty(value)) {
        Int.TryParse(value, out someValue);
      }
    }
