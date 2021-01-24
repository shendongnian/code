        public ctor()
        {            
            var waveFormat = new WaveFormat(16000, 16, 1);
            buffer = new BufferedWaveProvider(waveFormat)
            {
                BufferDuration = TimeSpan.FromSeconds(10),
                DiscardOnBufferOverflow = true
            };
        }
     
        internal void OnDataReceived(byte[] currentFrame)
        {
            if (mPlaying && mAudioTrack != null)
            {               
                buffer.AddSamples(currentFrame, 4, currentFrame.Length);
            }
        }
        
        internal void ConfigureCodec()
        {                   
            mAudioTrack = new WaveOut(WaveCallbackInfo.FunctionCallback());
            mAudioTrack.Init(buffer);
            if (mPlaying)
            {
                mAudioTrack.Play();
            }            
        }
