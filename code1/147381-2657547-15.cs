    public void InvertSignature(ref byte[] original, 
        bool invertHorizontal, bool invertVertical)
    {
        for (int i = 0; i < original.Length; i += 2)
        {
            if ((original[i] != 0) && (original[i + 1] != 0))
            {
                if (invertHorizontal)
                {
                    original[i] = 232 - original[i] - 1;
                }
                if (invertVertical)
                {
                    original[i + 1] = 64 - original[i + 1] - 1;
                }
            }
        }
    }
