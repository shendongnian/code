    static class AudioFileReaderExt
    {
        
        private static bool IsSilence(float amplitude, sbyte threshold)
        {
            double dB = 20 * Math.Log10(Math.Abs(amplitude));
            return dB < threshold;
        }
        private static bool IsBeep(float amplitude, sbyte threshold)
        {
            double dB = 20 * Math.Log10(Math.Abs(amplitude));
            return dB > threshold;
        }
        public static double GetBeepDuration(this AudioFileReader reader,
                                                  double StartPosition, sbyte silenceThreshold = -40)
        {
            int counter = 0;
            bool eof = false;
            int initial = (int)(StartPosition * reader.WaveFormat.Channels * reader.WaveFormat.SampleRate / 1000);
            if (initial > reader.Length) return -1;
            reader.Position = initial;
            var buffer = new float[reader.WaveFormat.SampleRate * 4];
            while (!eof)
            {
                int samplesRead = reader.Read(buffer, 0, buffer.Length);
                if (samplesRead == 0)
                    eof = true;
                for (int n = initial; n < samplesRead; n++)
                {
                    if (IsBeep(buffer[n], silenceThreshold))
                    {
                        counter++;
                    }
                    else
                    {
                        eof=true; break;
                    }
                }
            }
            double silenceSamples = (double)counter / reader.WaveFormat.Channels;
            double silenceDuration = (silenceSamples / reader.WaveFormat.SampleRate) * 1000;
            
            return TimeSpan.FromMilliseconds(silenceDuration).TotalMilliseconds;
        }
        public static double GetSilenceDuration(this AudioFileReader reader,
                                                  double StartPosition, sbyte silenceThreshold = -40)
        {
            int counter = 0;
            bool eof = false;
            int initial = (int)(StartPosition * reader.WaveFormat.Channels * reader.WaveFormat.SampleRate / 1000);
            if (initial > reader.Length) return -1;
            reader.Position = initial;
            var buffer = new float[reader.WaveFormat.SampleRate * 4];
            while (!eof)
            {
                int samplesRead = reader.Read(buffer, 0, buffer.Length);
                if (samplesRead == 0)                    
                    eof=true;
                for (int n = initial; n < samplesRead; n++)
                {
                    if (IsSilence(buffer[n], silenceThreshold))
                    {
                        counter++;
                    }
                    else
                    {
                        eof=true; break;
                    }
                }
            }
            double silenceSamples = (double)counter / reader.WaveFormat.Channels;
            double silenceDuration = (silenceSamples / reader.WaveFormat.SampleRate) * 1000;
            
            return TimeSpan.FromMilliseconds(silenceDuration).TotalMilliseconds;
        }
    }
