    // call this with "ABCDEFGH".ToCharArray()
    public void LoopWriter(char[] array)
    {
      for (int i = 0; i < array.Length - 2; i++)
      {
        for (int k = i + 1; k < array.Length - 1; k++)
        {
          for (int j = k + 1; j < array.Length; j++)
          {
            Console.WriteLine("{0}-{1}-{2}\n", array[i], array[k], array[j]);
          }
        }
      }
    }
