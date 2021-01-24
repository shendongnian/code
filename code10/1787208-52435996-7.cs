    public class PathProvider : IPathProvider {
        public string MapPath(string path) {
            return HostingEnvironment.MapPath(path);
        }
    }
    
