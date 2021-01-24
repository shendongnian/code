    public class CharacterClass : ScriptableObject{
        List<CharacterClassSubType> SubTypes; //Holds the list of all subtypes available to this class.
        CharacterClassSubType SelectedSubType; //The subtype chosen.
    }
    public class CharacterClassSubType : ScriptableObject{
        //Subtype code
    }
