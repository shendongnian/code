    public class SynonymComparer : IEqualityComparer<Synonym>
    {
       public bool Equals(Synonym one, Synonym two)
       {
            // Adjust according to requirements
            return StringComparer.InvariantCultureIgnoreCase
                                 .Equals(one.Name, two.Name);
       }
       public int GetHashCode(Synonym item)
       {
            return StringComparer.InvariantCultureIgnoreCase
                                 .GetHashCode(item.Name);
       }
    }
