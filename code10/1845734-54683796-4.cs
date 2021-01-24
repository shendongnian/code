    using System.Linq;
    //...
    public Module GetByName(string name)
    {
        return modules.FirstOrDefault(m  => string.Equals(m.name, name));
    }
    public Module GetByDifficulty(int difficulty)
    {
        return modules.FirstOrDefault(m => m.difficuty == difficulty));
    }
