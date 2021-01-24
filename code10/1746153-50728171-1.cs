        async Task<int> TaskDelayAsync(CancellationToken ct, IProgress<int> progress)
        {
            Debug.WriteLine(Quantity);
            int i = 0; 
            while (true)
            {               
                i++;
                //Debug.WriteLine(i);
                progress.Report(i);
                ct.ThrowIfCancellationRequested();
                await Task.Delay(500);
            }
            return i;
        }
