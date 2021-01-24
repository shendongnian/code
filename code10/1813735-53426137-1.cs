    public async Task<int> GetIntAfterLongWait()
    {
        await Task.Run(() =>
        {
            for (int i = 0; i < 500000000; i++)
            {
                if (i % 10000000 == 0)
                {
                    Console.WriteLine(i);
                }                
            }
        });
        return 23;
    }
