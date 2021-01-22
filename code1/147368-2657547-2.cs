    public void InvertSignature(ref byte[] original, 
        bool invertHorizontal, bool invertVertical)
    {
        int w = BitConverter.ToInt32(original, 0);
        int h = BitConverter.ToInt32(original, 4);
        // TO DO: blow up if w or h are > 255
        for (int i = 8; i < original.Length; i += 2)
        {
            if ((original[i] != 0) && (original[i + 1] != 0))
            {
                if (invertHorizontal)
                {
                    original[i] = w - original[i] - 1;
                }
                if (invertVertical)
                {
                    original[i + 1] = h - original[i + 1] - 1;
                }
            }
        }
    }
