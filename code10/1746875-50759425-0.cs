    public class StartObject {
        public List<FolderPack> ComplexData { get; set; }
    }
    [System.Serializable]
    public class FolderPack {
        public List<Folder> Folders { get; set; }
    }
    public class Folder {
        public string Path { get; set; }
        public string ExtraInfo { get; set; }
        public static implicit operator Folder(string path) {
            return new Folder(path);
        }
        public Folder() {
        }
        public Folder(string path) {
            this.Path = path;
        }
    }
