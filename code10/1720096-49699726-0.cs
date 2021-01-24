    private void ThreadProc()
        {
            Action item;
            while (queue.TryDequeue(out item))
            {
                item();
                System.Threading.Thread.Sleep(100);
            }
        }
