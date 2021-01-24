            public void PlayAudio(object sender, GenericEventArgs<Stream> args)
        {
            string fileName = $"{ Guid.NewGuid() }.wav";
            using (var file = File.OpenWrite(Path.Combine(Directory.GetCurrentDirectory(), fileName)))
            {
                args.EventData.CopyTo(file);
                file.Flush();
                Console.WriteLine(fileName);
            }
            WaveOut waveOut = new WaveOut();
            WaveFileReader reader = new WaveFileReader(fileName);
            waveOut.Init(reader);
            waveOut.Play();
            
        }
