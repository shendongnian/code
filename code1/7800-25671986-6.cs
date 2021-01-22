    //using System.Reflection;
    //using System.Linq;
    public static string AssemblyInformationalVersion
    {
        get
        {
            AssemblyInformationalVersionAttribute informationalVersion = (AssemblyInformationalVersionAttribute) 
                (AssemblyInformationalVersionAttribute.GetCustomAttributes(Assembly.GetExecutingAssembly())).Where( 
                    at => at.GetType().Name == "AssemblyInformationalVersionAttribute").First();
            return informationalVersion.InformationalVersion;
        }
    }
