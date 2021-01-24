    using System.Reflection;
    using System.Runtime.CompilerServices;
    
    [assembly: AssemblyTitle("Assembly.Fully.Qualified.Name")]
    [assembly: AssemblyDescription("")]
    
    #if DEBUG
    [assembly: InternalsVisibleTo("Assembly.Fully.Qualified.Name")]
    [assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
    #endif
