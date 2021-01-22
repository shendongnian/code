       public class EmbeddedVirtualFile : VirtualFile
    {
        public EmbeddedVirtualFile(string virtualPath)
            : base(virtualPath)
        {
        }
        internal static string GetResourceName(string virtualPath)
        {
            if (!virtualPath.Contains("/Views/"))
            {
                return null;
            }
            var resourcename = virtualPath
                .Substring(virtualPath.IndexOf("Views/"))
                .Replace("Views/", "OrangeGuava.Common.Views.")
                .Replace("/", ".");
            return resourcename;
        }
        public override Stream Open()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var resourcename = GetResourceName(this.VirtualPath);
            return assembly.GetManifestResourceStream(resourcename);
        }
    }
    public class EmbeddedViewPathProvider : VirtualPathProvider
    {
        private bool ResourceFileExists(string virtualPath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var resourcename = EmbeddedVirtualFile.GetResourceName(virtualPath);
            var result = resourcename != null && assembly.GetManifestResourceNames().Contains(resourcename);
            return result;
        }
        public override bool FileExists(string virtualPath)
        {
            return base.FileExists(virtualPath) || ResourceFileExists(virtualPath);
        }
        public override VirtualFile GetFile(string virtualPath)
        {
            if (!base.FileExists(virtualPath))
            {
                return new EmbeddedVirtualFile(virtualPath);
            }
            else
            {
                return base.GetFile(virtualPath);
            }
        }
    }
