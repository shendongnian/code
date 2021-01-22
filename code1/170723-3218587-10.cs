    namespace ConsoleApplication1
    {
        using System.Collections.Generic;
        using System.Text;
    
        public class Apple
        {
            // Define the set of valid properties for all apple objects.
            private static HashSet<string> AllowedProperties = new HashSet<string>(
                new string [] {
                    "Color",
                    "SeedCount"
                });
    
            // The main store for all properties
            private Dictionary<string, string> Properties = new Dictionary<string, string>();
    
            // Indexer for accessing properties
            // Access via the indexer should be restricted to the extension methods!
            // Unfortunately can't enforce this by making it private because then extension methods wouldn't be able to use it as they are now.
            public string this[string prop]
            {
                get
                {
                    if (!AllowedProperties.Contains(prop))
                    {
                        // throw exception
                    }
    
                    if (Properties.ContainsKey(prop))
                    {
                        return this.Properties[prop];
                    }
                    else
                    {
                        // TODO throw 'property unitialized' exeception || lookup & return default value for this property || etc.
                        
                        // this return is here just to make the sample runable
                        return "0"; 
                    }
                }
    
                set
                {
                    if (!AllowedProperties.Contains(prop))
                    {
                        // TODO throw 'invalid property' exception
    
                        // these assignments are here just to make the sample runable
                        prop = "INVALID";
                        value = "0";
                    }
    
                    this.Properties[prop] = value.ToString();
                }
            }
    
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
    
                foreach (var kv in this.Properties)
                {
                    sb.AppendFormat("{0}={1}\n", kv.Key, kv.Value);
                }
    
                return sb.ToString();
            }
        }
    }
