    private static readonly CharLookup _lookup = new CharLookup();
    
    private static void Main()
    {
       _lookup[CharacterClass.Mage, CharacterTrait.SingingAbility, 2] = 123;
       _lookup[CharacterClass.Mage, CharacterTrait.SingingAbility, 3] = 234;
       _lookup[CharacterClass.Soilder, CharacterTrait.MaxBeers, 3] = 23423;
    
       Console.WriteLine("Mage,SingingAbility,2 = " + _lookup[CharacterClass.Mage, CharacterTrait.SingingAbility, 2]);
       Console.WriteLine("Soilder,MaxBeers,3 = " + _lookup[CharacterClass.Soilder, CharacterTrait.MaxBeers, 3]);
    }
