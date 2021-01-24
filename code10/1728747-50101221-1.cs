    public class PathNames {
        private string _pathA = "Some Path";
        private string _pathB = "Another Path";
        
        public PathNames() {
            BaseDirectoryPath = Path.Combine(_pathA, _pathB);
        }
        
        public string BaseDirectoryPath { get; set; }
    }
    
