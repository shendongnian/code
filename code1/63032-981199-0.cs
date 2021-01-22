    public enum Animal
    {
       None = 0x00000000,
       AnimalTypeMask = 0xFFFF0000,
       Dog = 0x00010000,
       Cat = 0x00020000,
       Alsation = Dog | 0x00000001,
       Greyhound = Dog | 0x00000002,
       Siamese = Cat | 0x00000001
    }
    
    public static class AnimalExtensions
    {
      public bool IsAKindOf(this Animal animal, Animal type)
      {
        return (((int)animal) & AnimalTypeMask) == (int)type);
      }
    }
