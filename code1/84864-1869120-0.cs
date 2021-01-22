    class MyClass
    {
        private ManualResetEvent workFailedEvent = new ManualResetEvent(false);
        public List<ThreadResultDto> SendMailAsynch(List<ThreadRequestDto>  requestDto)
        {
            workFailedEvent.Reset();
            // --- The rest of your code as written in your post ---
        }
        private void DoAsyncWorkFirst()
        {
            try
            {
                for (int i = 0; i < 10000; i++)
                {
                    if (workFailedEvent.WaitOne(0, true))
                    {
                        break;
                    }
                    // -- Do some work here ---
                }
            }
            catch (MyException)
            {
                workFailedEvent.Set();
            }
        }
        private void DoAsyncWorkSecond()
        {
            try
            {
                for (int j = 0; j < 20000; j++)
                {
                    if (workFailedEvent.WaitOne(0, true))
                    {
                        break;
                    }
                    // --- Do some different work here ---
                }
            }
            catch (MyOtherException)
            {
                workFailedEvent.Set();
            }
        }
    }
