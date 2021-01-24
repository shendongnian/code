        public long ParallelGetDirectorySizesBytes(string root) {
            long dirsize = 0;
            string[] directories = Directory.GetDirectories(root);
            string[] files = Directory.GetFiles(root);
            if (files != null) {
                dirsize += ParallelGetFileSizesBytes(files);
            }
            Parallel.ForEach(directories, dir => {
                var size = ParallelGetDirectorySizesBytes(dir);
                lock (lockObject) {  //static lockObject defined at top of class
                    dirsize += size;
                }
            });
            return dirsize;
        }
        public long ParallelGetFileSizesBytes(string[] files) {
            long[] fileSizes = new long[files.Length];
            Parallel.For(0, files.Length, i => {
                fileSizes[i] = new FileInfo(files[i]).Length;
            });
            return fileSizes.Sum();
        }
