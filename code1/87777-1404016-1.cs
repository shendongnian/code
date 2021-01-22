    public void SetBuffer(Action<byte[], int, int> fnSet)
    {
        for (int i = 0; i < free.Length; i++)
        {
            if (1 == Interlocked.CompareExchange(ref free[i], 0, 1))
            {
                fnSet(buffer, i * blocksize, blocksize);
                return;
            }
        }
        fnSet(new byte[blocksize], 0, blocksize);
    }
