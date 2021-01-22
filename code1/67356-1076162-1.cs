    static void Main()
        {
            string targetFile = @"test.csproj";
            XDocument xmlDoc = XDocument.Load(targetFile);
            XNamespace ns = "http://schemas.microsoft.com/developer/msbuild/2003";
            var references = from reference in xmlDoc.Descendants(ns + "ItemGroup").Descendants(ns + "Reference")
                             select reference.Attribute("Include").Value;
            foreach (var reference in references)
            {
                Assembly.LoadWithPartialName(reference);
            }
            foreach (var item in AppDomain.CurrentDomain.GetAssemblies())
            {
                var assemblyVersion = ((AssemblyFileVersionAttribute)item.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), true)[0]).Version.ToString();
                Console.WriteLine("\r\nFullname:\t{0}\r\nFileVersion:\t{1}", item.FullName, assemblyVersion);
                
            }
            Console.WriteLine("\r\nPress any key to continue");
            Console.ReadKey();
        }
