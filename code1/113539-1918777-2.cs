       public class NestedIntStringDictionary: 
            NestedDictionary<int, int, string> 
       {
            public NestedIntStringDictionary(IEnumerable<> items)
            {
                foreach(Thing t in items)
                {
                    Dictionary<int, string> innrDict = 
                           ContainsKey(t.Foo)? this[t.Foo]: 
                               new Dictionary<int, string> (); 
                    if (innrDict.ContainsKey(t.Bar))
                       throw new ArgumentException(
                            string.Format(
                              "key value: {0} is already in dictionary", t.Bar));
                    else innrDict.Add(t.Bar, t.Baz);
                }
            }
       }
