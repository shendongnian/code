    private static async void DoHashes()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        await Task.Run(() =>
        {
            StringBuilder sb = new StringBuilder();
            foreach (var word in File.ReadLines(Input file path))
            {
               sb.AppendLine(MD5Hash(word));
            }
           File.AppendAllText(Output file path, sb.ToString());
        });
        sw.Stop();
        MessageBox.Show("Time Taken by Do Hashes : " + (sw.ElapsedMilliseconds / 1000.0) + " secs");
    }
