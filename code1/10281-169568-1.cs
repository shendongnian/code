    class Foo {
        public IEnumerable<FileInfo> LotsOfFile {
            get {
                for (int i=0; i < 100; i++) {
                    yield return new FileInfo("C:\\" + i + ".txt");
                }
            }
        }
        private List<FileInfo> files = new List<FileInfo>();
        public List<FileInfo> MoreFiles {
            get {
                return files;
            }
        }
        public ReadOnlyCollection<FileInfo> MoreFilesReadOnly {
            get {
                return files.AsReadOnly();
            }
        }
 
    }
