    public class CharLookup
    {
       private Dictionary<Tuple<CharacterClass, CharacterTrait, int>, int> myDict = new Dictionary<Tuple<CharacterClass, CharacterTrait, int>, int>();
    
       public int this[CharacterClass characterClass, CharacterTrait characterTrait, int level]
       {
          get => Check(characterClass, characterTrait, level);
          set => Add(characterClass, characterTrait, level, value);
       }
    
       public void Add(CharacterClass characterClass, CharacterTrait characterTrait, int level, int value)
       {
          var key = new Tuple<CharacterClass, CharacterTrait, int>(characterClass, characterTrait, level);
    
          if (myDict.ContainsKey(key))
             myDict[key] = value;
          else
             myDict.Add(key, value);
       }
    
       public int Check(CharacterClass characterClass, CharacterTrait characterTrait, int level)
       {
          var key = new Tuple<CharacterClass, CharacterTrait, int>(characterClass, characterTrait, level);
    
          if (myDict.TryGetValue(key, out var result))
             return result;
    
          throw new ArgumentOutOfRangeException("blah");
       }
    }
