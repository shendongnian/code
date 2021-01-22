    public class LookupTable
    {
       public readonly Dictionary<int, string> Table { get; }
       public readonly HashSet<int> ReservedKeys { get; }
       public LookupTable()
       {
          Table = new Dictionary<int, string>();
          ReservedKeys = new HashSet<int>();
       }
       public string Lookup(int key)
       {
          return (ReservedKeys.Contains(key))
             ? null
             : Table[key];
       }
    }
