    public static class BuildRandom
    {
         public IEnumerable<int> FillCollection(int capacity)
         {
              for(int index = 0; index < capacity; index++)
                   yield return Randomizer.Generate(0, 26);
         }
         public static int GetRandomNumber() => Randomizer.Generate(0, 26);
    }
