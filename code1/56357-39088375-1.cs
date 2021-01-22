        public static void TryToDoWithFileStream(string file, Action<FileStream> action, int count, int msecTimeOut)
        {
            FileStream stream = null;
            for (var i = 0; i < count; ++i)
            {
                try
                {
                    stream = File.OpenRead(file);
                    break;
                }
                catch (IOException)
                {
                    Thread.Sleep(msecTimeOut);
                }
            }
            action(stream);
        }
