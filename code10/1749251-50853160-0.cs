    public static class Util
    {
        public static int AddPerson(Person p, Dictionary<string, Person> list)
        {
            list.Add(p.Name, p);
            return list.Count;
        }  
    }  
