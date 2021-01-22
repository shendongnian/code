    public int doSomeWork(string value) {
       int someValue;
       if (String.IsNullOrEmpty(value)) {
          someValue = 0;
       } else {
          someValue = Int32.Parse(value);
       }
    }
