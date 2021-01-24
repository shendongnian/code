    using System.IO;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace UnitTestProject3
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                string[] lines = new string[5000000];
                for (int i = 0; i < 5000000; i++)
                {
                    lines[i] = $"Line_{i}";
                }
                Thread writerThread = new Thread(() =>
                {
                    File.WriteAllLines("C:\\tmp\\wal_test.txt", lines);
                });
                Thread readerThread = new Thread(() =>
                {
                    File.ReadLines("C:\\tmp\\wal_test.txt");
                });
                writerThread.Start();
                Thread.Sleep(100);
                readerThread.Start();
            }
        }
    }
