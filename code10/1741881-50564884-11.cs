        private static async void DoHashes()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            await Task.Run(() =>
            {
                foreach (var word in File.ReadLines(Input file path)
                {
                    File.AppendAllText(Output file path, MD5Hash(word) + Environment.NewLine);
                }
            }).ConfigureAwait(false);
            sw.Stop();
            MessageBox.Show("Time Taken by Do Hashes : " + (sw.ElapsedMilliseconds / 1000.0) + " secs");
        }
