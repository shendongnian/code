        public long GetDirectorySizesBytes(string root) {
            long dirsize = 0;
            string[] directories = Directory.GetDirectories(root);
            string[] files = Directory.GetFiles(root);
            if (files != null) {
                dirsize += GetFileSizesBytes(files);
            }
            foreach(var dir in directories) {
                var size = GetDirectorySizesBytes(dir);
                dirsize += size;
            }
            return dirsize;
        }
        public long GetFileSizesBytes(string[] files) {
            long[] fileSizes = new long[files.Length];
            for(int i = 0; i < files.Length; i++) {
                fileSizes[i] = new FileInfo(files[i]).Length;
            }
            return fileSizes.Sum();
        }
