    using System.Linq;
    //...
    public Module GetByName(string name)
    {
        return modules.FirstOrDefault(m => string.Equals(m.name, name));
    }
