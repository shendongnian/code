    public enum Animal
    {
        CAT_type1= AnimalGroup.CAT,
        CAT_type2 = AnimalGroup.CAT,
        DOG_type1 = AnimalGroup.DOG,
    }
    public enum AnimalGroup
    {
        CAT,
        DOG
    }
    public static class AnimalExtensions
    {
        public static bool isGroup(this Animal animal,AnimalGroup groupNumber)
        {
            if ((AnimalGroup)animal == groupNumber)
                return true;
            return false;
        }
    }
