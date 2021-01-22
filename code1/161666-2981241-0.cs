        private static long DirSize(string sourceDir, bool recurse)
        {
            long size = 0;
            string[] fileEntries = Directory.GetFiles(sourceDir);
            foreach (string fileName in fileEntries)
            {
                Interlocked.Add(ref size, (new FileInfo(fileName)).Length);
            }
            if (recurse)
            {
                string[] subdirEntries = Directory.GetDirectories(sourceDir);
                Parallel.For<long>(0, subdirEntries.Length, () => 0, (i, loop, subtotal) =>
                {
                    if ((File.GetAttributes(subdirEntries[i]) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                    {
                        subtotal += DirSize(subdirEntries[i], true);
                        return subtotal;
                    }
                    return 0;
                },
                    (x) => Interlocked.Add(ref size, x)
                );
            }
            return size;
        }
