    public override VirtualDirectory GetDirectory(string virtualDir)
        {
            Log.LogInfo("GetDirectory - " + virtualDir);
            var b = base.GetDirectory(virtualDir);
            return new EmbeddedVirtualDirectory(virtualDir, b);
        }
    public class EmbeddedVirtualDirectory : VirtualDirectory
    {
        private VirtualDirectory FileDir { get; set; } 
        public EmbeddedVirtualDirectory(string virtualPath, VirtualDirectory filedir)
            : base(virtualPath)
        {
            FileDir = filedir;
        }
        public override System.Collections.IEnumerable Children
        {
            get { return FileDir.Children; }
        }
        public override System.Collections.IEnumerable Directories
        {
            get { return FileDir.Directories; }
        }
        public override System.Collections.IEnumerable Files
        {
            get {
                if (!VirtualPath.Contains("/Views/") || VirtualPath.EndsWith("/Views/"))
                {
                    return FileDir.Files;
                }
                var fl = new List<VirtualFile>();
                foreach (VirtualFile f in FileDir.Files)
                {
                    fl.Add(f);
                }
                
                var resourcename = VirtualPath.Substring(VirtualPath.IndexOf("Views/"))
    .Replace("Views/", "OrangeGuava.Common.Views.")
    .Replace("/", ".");
                Assembly assembly = Assembly.GetExecutingAssembly();
                var rfl = assembly.GetManifestResourceNames()
                    .Where(s => s.StartsWith(resourcename))
                    .Select(s => VirtualPath + s.Replace(resourcename, ""))
                    .Select(s => new EmbeddedVirtualFile(s));
                fl.AddRange(rfl);
                return fl;
            }
        }
    }
