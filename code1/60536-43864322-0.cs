    private void GetSubArrayThroughArraySegment() {
      int[] array = { 10, 20, 30 };
      ArraySegment<int> segment = new ArraySegment<int>(array,  1, 2);
      Console.WriteLine("-- Array --");
      int[] original = segment.Array;
      foreach (int value in original)
      {
        Console.WriteLine(value);
      }
      Console.WriteLine("-- Offset --");
      Console.WriteLine(segment.Offset);
      Console.WriteLine("-- Count --");
      Console.WriteLine(segment.Count);
      
      Console.WriteLine("-- Range --");
      for (int i = segment.Offset; i <= segment.Count; i++)
      {
        Console.WriteLine(segment.Array[i]);
      }
    }
