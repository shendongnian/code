    class MyEffects : ISampleProvider
    {
        private readonly ISampleProvider source;
        public MyEffects(ISampleProvider source)
        {
            this.source = source;
        }
        public WaveFormat { get { return source.WaveFormat; } }
        public int Read(float[] buffer, int offset, int read)
        {
             var samplesRead = source.Read(buffer, offset, read);
             for(int n = 0; n < samplesRead; n++)
             {
                 // do cool stuff here to change the value of 
                 // the sample in buffer[offset+n]
             }
             return samplesRead;
        }
    }
