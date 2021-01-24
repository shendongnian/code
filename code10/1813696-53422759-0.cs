    private async Task<List<long>> ReturnListArrayLong()
    {
        if (MemOpen())
        {
            byte[] bPosition = new byte[290];
            mmfvs.Read(bPosition, 0, 290);
            Buffer.BlockCopy(bPosition, 0, data, 0, bPosition.Length);
            List<long> ArrayLong = new List<long>();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != 0)
                {
                    await Task.Run(() => ArrayLong.AddRange(data[i]));
                }
               await Task.Delay(10);
            }
            return ArrayLong;
        }
    }
