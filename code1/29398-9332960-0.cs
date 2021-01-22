    string assemblyName = "library.dll";
    string assemblyPath = HttpContext.Current.Server.MapPath("~/bin/" + assemblyName);
    Assembly assembly = Assembly.LoadFrom(assemblyPath);
    Type T = assembly.GetType("Company.Project.Classname");
    Company.Project.Classname instance = (Company.Project.Classname) Activator.CreateInstance(T);
