    public void InvertSignature(ref byte[] original, 
        bool invertHorizontal, bool invertVertical)
    {
        byte w = (byte)BitConverter.ToInt16(original, 0) - 1;
        byte h = (byte)BitConverter.ToInt16(original, 2) - 1;
        // TO DO: blow up if w or h are > 255
        for (int i = 4; i < original.Length; i += 2)
        {
            if ((original[i] != 0) && (original[i + 1] != 0))
            {
                if (invertHorizontal)
                {
                    original[i] = w - original[i];
                }
                if (invertVertical)
                {
                    original[i + 1] = h - original[i + 1];
                }
            }
        }
    }
