        float f = 2.0f;
        int i;
        // perform unsafe cast (preserving raw binary)
        unsafe
        {
            float* fRef = &f;
            i = *((int*)fRef);
        }
        Console.WriteLine(i);
        // prove same answer long-hand
        byte[] raw = BitConverter.GetBytes(f);
        int j = BitConverter.ToInt32(raw, 0);        
        Console.WriteLine(j);
