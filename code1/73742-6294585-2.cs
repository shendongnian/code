    public class KeyValuePair
      {
        public string Key { get; set; }
    
        public string Name { get; set; }
        public int Value { get; set; }
    
        public static List<KeyValuePair> ListFrom<T>()
        {
          var array = (T[])(Enum.GetValues(typeof(T)).Cast<T>());
          return array
            .Select(a => new KeyValuePair
              {
                Key = a.ToString(),
                Name = a.ToString().SplitCapitalizedWords(),
                Value = Convert.ToInt32(a)
              })
              .OrderBy(kvp => kvp.Name)
             .ToList();
        }
      }
