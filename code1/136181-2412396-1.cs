    public static byte[] Encode(string input, string reference) {
      int size = 1;
      while ((1 << ++size) < reference.Length);
      byte[] result = new byte[(size * input.Length + 7) / 8];
      new BitArray(
        input
        .Select(c => {
          int index = reference.IndexOf(c);
          return Enumerable.Range(0, size).Select(i => (index & (1 << i)) != 0);
        })
        .SelectMany(a => a)
        .ToArray()
      ).CopyTo(result, 0);
      return result;
    }
    
    public static string Decode(byte[] encoded, int length, string reference) {
      int size = 1;
      while ((1 << ++size) < reference.Length);
      return new String(
        new BitArray(encoded)
          .Cast<bool>()
          .Take(length * size)
          .Select((b, i) => new { Index = i / size, Bit = b })
          .GroupBy(g => g.Index)
          .Select(g => reference[g.Select((b, i) => (b.Bit ? 1 : 0) << i).Sum()])
          .ToArray()
      );
    }
