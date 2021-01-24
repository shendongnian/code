        public async void Button_Click()
        {
            await DoMyWorkAsync();
        }
        private async Task DoMyWorkAsync()
        {
            await Task.Run(() =>
            {
                jobs = new int[] { 0, 20, 10, 13, 12 };
                Parallel.ForEach(jobs, job_i =>
                {
                    DoSomething(job_i);
                    done.Enqueue(job_i);
                });
            });
        }
