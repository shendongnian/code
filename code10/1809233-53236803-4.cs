    public static float MicLoudFloat;
    private float sample_max = 0;
    // ...
    void StopMicrophone()
    {
        Microphone.End(theMicroDevice);
        Maximum_Level(); // Collect the final sample
        MicLoudFloat = sample_max;
        print(MicLoudFloat);
        // 1.5
    }
    
    // ...
    
    float Maximum_Level()
    {
        float[] waveData = new float[samplesWindows];
        int micPosition = Microphone.GetPosition(null) - (samplesWindows + 
        1); // null means the first microphone
        if (micPosition < 0) return 0;
        recordOfClips.GetData(waveData, micPosition);
        // Getting a peak on the last 128 samples
        for (int i = 0; i < samplesWindows; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (wavePeak > sample_max)
            {
                sample_max= wavePeak
            }
        }
        return sample_max;
     }
    // ...
    void Update()
    {
        // ...
        Maximum_Level();
    }
