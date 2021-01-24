            public void PlayAudio(object sender, GenericEventArgs<Stream> args)
        {
            fileName = $"{ Guid.NewGuid() }.wav";
            using (var file = File.OpenWrite(Path.Combine(Directory.GetCurrentDirectory(), fileName)))
            {
                args.EventData.CopyTo(file);
                file.Flush();
            }
            waveOut = new WaveOut();
            reader = new WaveFileReader(fileName);
            waveOut.Init(reader);
            waveOut.PlaybackStopped += OnPlayStopped;
            waveOut.Play();
        }
        private async void OnPlayStopped(object sender, StoppedEventArgs e)
        {
            Console.WriteLine("Done");
            await Task.Run(() =>
            {
                reader.Dispose();
                waveOut.Dispose();
                File.Delete(fileName);
            });
        }
