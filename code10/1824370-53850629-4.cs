    private static IEnumerable<string> Generator(int length = 5) {
      string item = new string('0', length);
      do {
        yield return item;
        item = GetNextValue(item);
      }
      while (!item.All(c => c == '0'));
    }
   
