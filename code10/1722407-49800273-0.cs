    using System;
    using System.Reflection;
    
    [assembly:AssemblyVersion("1.2.*")]
    
    class Test
    {
        static void Main()
        {
            var version = typeof(Test).GetTypeInfo().Assembly.GetName().Version;
            Console.WriteLine(version);
            Console.WriteLine(ConvertToDateTime(version));
        }
            
        static DateTime ConvertToDateTime(Version version) =>
            new DateTime(2000, 1, 1)
                .AddDays(version.Build)
                .AddSeconds(version.Revision * 2);
    }
