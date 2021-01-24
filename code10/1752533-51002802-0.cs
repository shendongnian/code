    private class SampleSource : ISampleSource
    {
        public long Position { get; set; }
        public WaveFormat WaveFormat { get; private set; }
        public bool CanSeek => true;
        public long Length  => _data.Length;
    
        private float[] _data;
        private long readPoint = 0;
    
        public SampleSource(float[][] samples, int sampleRate, int bits, int channels)
        {
            WaveFormat = new WaveFormat(sampleRate, bits, channels);
            if (samples.Length <= 0) return;
    
            _data = new float[samples[0].Length * samples.Length];
            int cchannels = samples.Length;
            int sampleLength = samples[0].Length;
    
            for (var i = 0; i < sampleLength; i += cchannels)
                for (var n = 0; n < cchannels; n++)
                    _data[i + n] = samples[n][i / cchannels];
        }
    
        public int Read(float[] buffer, int offset, int count)
        {
            if (_data.Length < Position + count)
                count = (int) (_data.Length - Position);
    
            for (var i = 0; i < count; i++)
                buffer[i] = _data[i + Position + offset];
    
            Position += count;
            return count;
        }
    
        public void Dispose() =>_data = null;
    }
