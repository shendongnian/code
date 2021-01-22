    float[] test = new float[10000000];
    Random rnd = new Random();
    for (int i = 0; i < test.Length; i++)
    {
        byte[] buffer = new byte[4];
        rnd.NextBytes(buffer);
        float rndfloat = BitConverter.ToSingle(buffer, 0);
        switch(i){
            case 0: { test[i] = float.MaxValue; break; }
            case 1: { test[i] = float.MinValue; break; }
            case 2: { test[i] = float.NaN; break; }
            case 3: { test[i] = float.NegativeInfinity; break; }
            case 4: { test[i] = float.PositiveInfinity; break; }
            case 5: { test[i] = 0f; break; }
            default: { test[i] = test[i] = rndfloat; break; }
        }
    }
