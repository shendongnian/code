    [TestClass]
    public class FileWriteTests
    {
        
        [TestMethod]
        public void TestMethodAfterClose_filetailing()
        {
            var currentDir = Environment.CurrentDirectory;
            var fileToMonitor = "test.txt";
            File.Delete(Path.Combine(currentDir, fileToMonitor));
            List<string> output = new List<string>();
            using (var watcherTest = new PersonalFileTail(currentDir, fileToMonitor))
            {
                watcherTest.StartTail(delegate (string line) { output.Add(line); });
                using (var writer = new StreamWriter(Path.Combine(currentDir, fileToMonitor), true))
                {
                    writer.WriteLine($"test");
                    writer.Flush();
                }
                System.Threading.Thread.Sleep(200);
                watcherTest.StopTail();
            }
            System.Threading.Thread.Sleep(10);
            Assert.AreEqual(1, output.Count);
            Assert.AreEqual("test", output[0]);
        }
        [TestMethod]
        public void TestMethodAfterFlush_filetailing()
        {
            // initiate file
            var currentDir = Environment.CurrentDirectory;
            var fileToMonitor = "test.txt";
            File.Delete(Path.Combine(currentDir, fileToMonitor));
            FileInfo info = new FileInfo(Path.Combine(currentDir, fileToMonitor));
            List<string> output = new List<string>();
            using (var watcherTest = new PersonalFileTail(currentDir, fileToMonitor))
            {
                watcherTest.StartTail(delegate (string line) { output.Add(line); });
                using (var writer = new StreamWriter(Path.Combine(currentDir, fileToMonitor), true))
                {
                    try
                    {
                        writer.WriteLine($"test");
                        writer.Flush();
                        System.Threading.Thread.Sleep(1000);
                        Assert.AreEqual(1, output.Count);
                        Assert.AreEqual("test", output[0]);
                    }
                    catch
                    {
                        Assert.Fail("Test failed");
                    }
                }
                watcherTest.StopTail();
            }
        }
        public class PersonalFileTail : IDisposable
        {
            private string filename;
            private string directory;
            private Task fileTailTask;
            private Action<string> handleResults;
            private volatile bool runTask;
            private long lastFilePosition;
            public string FileName
            {
                get { return Path.Combine(directory, filename); }
            }
            public PersonalFileTail(string directory, string filename)
            {
                this.directory = directory;
                this.filename = filename;
                this.runTask = false;
                lastFilePosition = 0;
            }
            public void StartTail(Action<string> handleResults)
            {
                this.handleResults = handleResults;
                runTask = true;
                fileTailTask = Task.Run(() => MonitorFileTask());
            }
            public void StopTail()
            {
                runTask = false;
                fileTailTask.Wait();
            }
            public IEnumerable<string> ReadLinesFromFile()
            {
                using (StreamReader reader = new StreamReader(new FileStream(FileName,
                FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        yield return line;
                    }
                    lastFilePosition = reader.BaseStream.Length;
                }
            }
            public void MonitorFileTask()
            {
                StreamReader reader = null;
                FileStream stream = null;
                try
                {
                    using(stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (reader = new StreamReader(stream))
                    {
                        do
                        {
                            //if the file size has increased do something
                            if (reader.BaseStream.Length > lastFilePosition)
                            {
                                //seek to the last max offset
                                reader.BaseStream.Seek(lastFilePosition, SeekOrigin.Begin);
                                //read out of the file until the EOF
                                string line = "";
                                while ((line = reader.ReadLine()) != null)
                                {
                                    handleResults(line);
                                }
                                //update the last max offset
                                lastFilePosition = reader.BaseStream.Position;
                            }
                            // sleep task for 100 ms 
                            System.Threading.Thread.Sleep(100);
                        }
                        while (runTask);
                    }
                }
                catch
                {
                    if (reader != null)
                        reader.Dispose();
                    if (stream != null)
                        stream.Dispose();
                }
            }
            public void Dispose()
            {
                if(runTask)
                {
                    runTask = false;
                    fileTailTask.Wait();
                }
            }
        }
    }
