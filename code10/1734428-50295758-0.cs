    public class Program {
        public static void Main() {
            string path = @"G:\tmp\so\tmp.file";
            // create file with delete share and don't close handle
            var file = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.Delete);
            DestroyFile(path);
            GC.KeepAlive(file);
        }
        private static void DestroyFile(string path) {
            try {
                
                if (File.Exists(path)) {
                    // no error
                    File.Delete(path);
                }
                // but still exists
                if (File.Exists(path)) {
                    throw new IOException(string.Format("Failed to delete file: '{0}'.", path));
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
