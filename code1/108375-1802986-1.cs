    public List<Person> GetFemale(List<Person> people)
    {
       List<Person> results = new List<Person>();
       foreach (Person p in people)
       {
           if (!p.IsMale)
              results.Add(p);
       }
       return results;
    }
