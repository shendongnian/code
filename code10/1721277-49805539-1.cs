        public static Version GetVersion()
        {
            string runtimePath = System.IO.Path.GetDirectoryName(typeof(object).Assembly.Location);
            // Making the assumption that the path looks like this
            // C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.0.6
            string version = runtimePath.Substring(runtimePath.LastIndexOf('\\') + 1);
            return new Version(version);
        }
