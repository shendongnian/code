        public static bool AreFilesIdenticalFast(string path1, string path2)
        {
            return AreFilesIdentical(path1, path2, AreStreamsIdenticalFast);
        }
        public static bool AreFilesIdentical(string path1, string path2)
        {
            return AreFilesIdentical(path1, path2, AreStreamsIdentical);
        }
        public static bool AreFilesIdentical(string path1, string path2, Func<Stream, Stream, bool> areStreamsIdentical)
        {
            if (path1 == null)
                throw new ArgumentNullException(nameof(path1));
            if (path2 == null)
                throw new ArgumentNullException(nameof(path2));
            if (areStreamsIdentical == null)
                throw new ArgumentNullException(nameof(path2));
            if (!File.Exists(path1) || !File.Exists(path2))
                return false;
            using (var thisFile = new FileStream(path1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var valueFile = new FileStream(path2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    if (valueFile.Length != thisFile.Length)
                        return false;
                    if (!areStreamsIdentical(thisFile, valueFile))
                        return false;
                }
            }
            return true;
        }
        public static bool AreStreamsIdenticalFast(Stream stream1, Stream stream2)
        {
            if (stream1 == null)
                throw new ArgumentNullException(nameof(stream1));
            if (stream2 == null)
                throw new ArgumentNullException(nameof(stream2));
            const int bufsize = 80000; // 80000 is below LOH (85000)
            var tasks = new List<Task<bool>>();
            do
            {
                // consumes more memory (two buffers for each tasks)
                var buffer1 = new byte[bufsize];
                var buffer2 = new byte[bufsize];
                int read1 = stream1.Read(buffer1, 0, buffer1.Length);
                if (read1 == 0)
                {
                    int read3 = stream2.Read(buffer2, 0, 1);
                    if (read3 != 0) // not eof
                        return false;
                    break;
                }
                // both stream read could return different counts
                int read2 = 0;
                do
                {
                    int read3 = stream2.Read(buffer2, read2, read1 - read2);
                    if (read3 == 0)
                        return false;
                    read2 += read3;
                }
                while (read2 < read1);
                // consumes more cpu
                var task = Task.Run(() =>
                {
                    return IsSame(buffer1, buffer2);
                });
                tasks.Add(task);
            }
            while (true);
            Task.WaitAll(tasks.ToArray());
            return !tasks.Any(t => !t.Result);
        }
        public static bool AreStreamsIdentical(Stream stream1, Stream stream2)
        {
            if (stream1 == null)
                throw new ArgumentNullException(nameof(stream1));
            if (stream2 == null)
                throw new ArgumentNullException(nameof(stream2));
            const int bufsize = 80000; // 80000 is below LOH (85000)
            var buffer1 = new byte[bufsize];
            var buffer2 = new byte[bufsize];
            var tasks = new List<Task<bool>>();
            do
            {
                int read1 = stream1.Read(buffer1, 0, buffer1.Length);
                if (read1 == 0)
                    return stream2.Read(buffer2, 0, 1) == 0; // check not eof
                // both stream read could return different counts
                int read2 = 0;
                do
                {
                    int read3 = stream2.Read(buffer2, read2, read1 - read2);
                    if (read3 == 0)
                        return false;
                    read2 += read3;
                }
                while (read2 < read1);
                if (!IsSame(buffer1, buffer2))
                    return false;
            }
            while (true);
        }
        public static bool IsSame(byte[] bytes1, byte[] bytes2)
        {
            if (bytes1 == null)
                throw new ArgumentNullException(nameof(bytes1));
            if (bytes2 == null)
                throw new ArgumentNullException(nameof(bytes2));
            if (bytes1.Length != bytes2.Length)
                return false;
            for (int i = 0; i < bytes1.Length; i++)
            {
                if (bytes1[i] != bytes2[i])
                    return false;
            }
            return true;
        }
