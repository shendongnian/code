    namespace WebApplication1
    {
        public class Global : System.Web.HttpApplication
        {
    
            protected void Application_Start(object sender, EventArgs e)
            {
                AppDomain currentDomain = AppDomain.CurrentDomain;
                currentDomain.AssemblyResolve += new ResolveEventHandler(currentDomain_AssemblyResolve);
            }
    
            System.Reflection.Assembly currentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            {
                if (args.Name == "ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
                {
                    String assemblyPath = @"C:\Projects\StackOverflowAnswers\WebApplication1\ClassLibrary1\bin\Debug\ClassLibrary1.dll";
                    Assembly assembly = Assembly.LoadFrom(assemblyPath);
                    return assembly;
                }
                return null;
    
            }
    .....
