    float[] samples = { 0.0f, 4.0f, 2.5f, 2.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
    var clean = new List<float>();
    for (int i = 0; i <samples.Length; i++)
    {
        if (i == 0)
        {
            if (samples[i] == 0.0f) clean.Add(samples[i]);
            continue;
        }
        if (samples[i] != 0.0f) clean.Add(samples[i]);
    }
    //clean.ToArray() = float[]
