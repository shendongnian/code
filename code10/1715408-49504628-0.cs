    public List<PersonWithOneChildMax> BuildFromPersonList(List<Person> people)
    {
        var ancestors = new List<Person>();
        var result = new List<PersonWithOneChildMax>();
        foreach (person in people)
        {
            BuildDescendants(person, ancestors, result);
        }
        return result;
    }
    private BuildDescendants(Person person, List<Person> ancestors, List<PersonWithOneChildMax> result)
    {
        if (person.Children.Count == 0)
        {
            var newPerson = new PersonWithOneChildMax {Name = person.Name, Child = null};
            // build the hierarchy backwards
            for (var i = ancestors.Count - 1; i >= 0; --i)
            {
                newPerson = new PersonWithOneChildMax {Name = ancestors[i].Name, Child = newPerson};
            }
            result.Add(newPerson);
        }
        else
        {
            ancestors.Add(person);
            foreach (var child in person.Children)
            {
                BuildDescendants(child, ancestors, result);
            }
            ancestors.RemoveAt(ancestors.Count-1);
        }
    }
