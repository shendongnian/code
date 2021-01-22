      public List<People> SearchPeople(Dictionary<string, string> fieldValueDictionary)
            {
                return !fieldValueDictionary.Any()
                       ? entities.People 
                       : entities.People.Where(p => fieldValueDictionary.All(kvp => PropertyStringEquals(p, kvp.Key, kvp.Value)))
                                        .ToList();
            }
    
      private bool PropertyStringEquals(object obj, string propertyName, string comparison)
            {
                var val = obj.GetType().GetProperty(propertyName).GetValue(obj, null);
                return val == null ? comparison == null : val.ToString() == comparison; ;
            }
