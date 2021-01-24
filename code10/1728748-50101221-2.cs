    public class PathNames {
        private string _pathA = "Some Path";
        private string _pathB = "Another Path";
        
        public string BaseDirectoryPath { 
            get {
                return Path.Combine(_pathA, _pathB);
            }
            set {
                //No OP
            }
        }
    }
