    public static void Resize(ref string [] ip, ref int i)    
    {
        for (int k = i; k < (ip.Length - 2); k++)
        {
            ip[k] = ip[k + 2];
        }    
        Array.Resize(ref ip, ip.Length - 2);    
        j = j - 2;
        i--;
    }
