    Hashtable one = GetHashtableFromSomewhere();
    Hashtable two = GetAnotherHashtableFromSomewhere();
    one.UpdateWith(two);
    // ...
    public static class HashtableExtensions
    {
        public static void UpdateWith(this Hashtable first, Hashtable second)
        {
            foreach (DictionaryEntry item in second)
            {
                first[item.Key] = item.Value;
            }
        }
    }
