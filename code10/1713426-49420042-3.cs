    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    namespace StackOverflowProjects.Tests {
    [TestClass]
    public class DirectorySizeTests {
        public static object lockObject = new object();
        [TestMethod]
        public void GetDirectoriesSizesTest() {
            var actual = GetDirectorySizesBytes(@"C:\Exchanges");
            var parallelActual = ParallelGetDirectorySizesBytes(@"C:\Exchanges");
            long expected = 25769767281;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, parallelActual);
        }
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
        public long ParallelGetDirectorySizesBytes(string root) {
            long dirsize = 0;
            string[] directories = Directory.GetDirectories(root);
            string[] files = Directory.GetFiles(root);
            if (files != null) {
                dirsize += ParallelGetFileSizesBytes(files);
            }
            Parallel.ForEach(directories, dir => {
                var size = ParallelGetDirectorySizesBytes(dir);
                lock (lockObject) {
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
        }
    }
