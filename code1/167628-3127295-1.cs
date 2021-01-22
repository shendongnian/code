    using System.Reflection;
    string company = ((AssemblyCompanyAttribute)Assembly
        .GetExecutingAssembly()
        .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)[0])
        .Company;
