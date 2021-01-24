    static void morseCode(string p)
    {
        for(int i=0; i<p.Length; i++)
        {
            Console.Write(morseEncode(p[i]) + "/");
        }
    }
