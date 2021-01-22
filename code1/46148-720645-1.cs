    public Person MergePersonGroup(IGrouping<string, Person> pGroup) {
      var l = pGroup.ToList(); // Avoid multiple enumeration.
      var first = l.First();
      var result = new Person {
        Name = first.Name,
        Value = first.Value
      };
      if (l.Count() == 1) {
        return result;
      } else if (l.Count() == 2) {
        result.Change = first.Value - l.Last().Value;
        return result;
      } else {
        throw new ApplicationException("Too many " + result.Name);
      }
    }
