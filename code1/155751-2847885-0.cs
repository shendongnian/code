    using System.Resources;
    using System.Reflection;
    
    ResourceManager rm = new ResourceManager("YourProgramName.ProgramResources",
    Assembly.GetExecutingAssembly());
    
    rm.GetObject("my_icon_name");
