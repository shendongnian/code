        public delegate void IoOperation(params string[] parameters);
        public void FileDeleteOperation(params string[] fileName)
        {
            File.Delete(fileName[0]);
        }
        public void FileCopyOperation(params string[] fileNames)
        {
            File.Copy(fileNames[0], fileNames[1]);
        }
        public void RetryFileIO(IoOperation operation, params string[] parameters)
        {
            RetryTimer fileIORetryTimer = new RetryTimer(TimeSpan.FromHours(10));
            bool success = false;
            while (!success)
            {
                try
                {
                    operation(parameters);
                    success = true;
                }
                catch (IOException e)
                {
                    if (fileIORetryTimer.HasExceededRetryTimeout)
                    {
                        throw;
                    }
                    fileIORetryTimer.SleepUntilNextRetry();
                }
            }
        }
        public void Foo()
        {
            this.RetryFileIO(FileDeleteOperation, "L:\file.to.delete" );
            this.RetryFileIO(FileCopyOperation, "L:\file.to.copy.source", "L:\file.to.copy.destination" );
        }
