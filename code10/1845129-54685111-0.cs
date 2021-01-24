    public class City
    {
        public City(string name)
        {
          Name = name;
          CleanedNames = StringUtils.CleanToSearch(name);
        }
    
        string Name {get;}
        IEnumerable<string> CleanedNames {get;}
    }
