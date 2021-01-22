      /// <summary>
      /// Only works for version numbers in the form a ( . b ( . c ( . d )? )? )?
      /// </summary>
      public class VersionComponents : IComparable<VersionComponents>
      {
        readonly int[] components;
    
        int[] GetComponents(string cpnumber)
        {
          var tokens = cpnumber.Split(".".ToCharArray(), 
                                       StringSplitOptions.RemoveEmptyEntries);
          return tokens.Select(x => Convert.ToInt32(x)).ToArray();
        }
    
        public VersionComponents(string cpnumber)
        {
          components = GetComponents(cpnumber);
        }
    
        public int this[int index]
        {
          get { return components.Length > index ? components[index] : 0; }
        }
    
        public int CompareTo(VersionComponents other)
        {
          for (int i = 0; i < components.Length || 
                          i < other.components.Length; i++)
          {
            var diff = this[i].CompareTo(other[i]);
            if (diff != 0)
            {
              return diff;
            }
          }
    
          return 0;
        }
      }
