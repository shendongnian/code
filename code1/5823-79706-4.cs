    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    //...
    static IEnumerable<string> GetClasses(string nameSpace)
    {
        Assembly asm = Assembly.GetExecutingAssembly();
        return asm.GetTypes()
			.Where(type => type.Namespace == nameSpace)
			.Select(type => type.Name);
    }
