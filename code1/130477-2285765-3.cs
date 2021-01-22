    Dictionary<Predicate<Something>, Action> mappings = {{...}}
    bool shouldDoAnything = mappings.Keys.Aggregate(true, (accum, condition) => 
        accum || condition);
    if (shouldDoAnything)
    {
       //do semi-specific things
       foreach(DictionaryEntry<Predicate<Something>, Action> mapping in mappings)
       {
          if (mapping.Key(input))
          {
             mapping.Value(); //do specific things
             break;
          }
        }
    }
