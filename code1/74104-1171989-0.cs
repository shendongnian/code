     public MyClass<k1, k2, T>: Dictionary<object, T>
      {
          private Dictionary<k1, k2> keyMap;
          public new Add(k1 key1Val, k2 key2Val, T object)
          {
             keyMap.Add(key1Val, key2Val);
             base.Add(k2, object)
          }
          public Remove(k1 key1Val) 
          { 
              base.Remove(keyMap[key1Val]); 
              keyMap.Remove(key1Val);
          }
          public Remove(k2 key2Val) 
          { 
            base.Remove(key2Val);
            keyMap.Remove(key2Val);
          }
      }
