    //using System.Reflection;
    //using System.Linq;
    public static string AssemblyInformationalVersion
    {
        get
        {
            AssemblyInformationalVersionAttribute InformationalVersion = (AssemblyInformationalVersionAttribute) 
                (AssemblyInformationalVersionAttribute.GetCustomAttributes(Assembly.GetExecutingAssembly())).Where( 
                    at => at.GetType().Name == "AssemblyInformationalVersionAttribute").First();
            return InformationalVersion.InformationalVersion;
        }
    }
