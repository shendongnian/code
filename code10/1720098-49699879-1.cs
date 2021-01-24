    private async void ThreadProc()
        {
            while (true)
            {
                Action item;
                bool isSuccessfull = false;
                isSuccessfull = queue.TryDequeue(out item);
                if (isSuccessfull)
                {
                    item();
                }
                await Task.Delay(300);
            }
        }
