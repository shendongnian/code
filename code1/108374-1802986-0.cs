    public List<Person> GetMale(List<Person> people)
    {
       List<Person> results = new List<Person>();
       foreach (Person p in people)
       {
           if (p.IsMale)
              results.Add(p);
       }
       return results;
    }
