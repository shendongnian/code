        private static async void DoHashes()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            await Task.Run(() =>
            {
                foreach (var word in File.ReadLines(Input File)
                {
                    File.AppendAllText(Output File, MD5Hash(word) + Environment.NewLine);
                }
            }).ConfigureAwait(false);
            sw.Stop();
            MessageBox.Show("Time Taken by Do Hashes : " + (sw.ElapsedMilliseconds / 1000.0) + " secs");
        }
