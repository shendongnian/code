    private async Task<int> CountLines(string path)
    {
        int count = 0;
        await Task.Run(() =>
        {
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                while (sr.ReadLine() != null)
                {
                    count++;
                }
            }
        });
        return count;
    }
