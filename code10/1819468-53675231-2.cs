    //using System.Reflection;
    //using System.Runtime.Versioning;
    var framework = Assembly.GetEntryAssembly()?
        .GetCustomAttribute<TargetFrameworkAttribute>()?
        .FrameworkName;
    MessageBox.Show(framework);
