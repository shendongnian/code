    using System.Linq;
    public bool Exist(List<IMyInterface> objects, IMyInterface typeToCheck)
    {
       return objects.Any(t => t.ObjectName == typeToCheck.ObjectName);
    }
