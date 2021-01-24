    public static string IncreasePassword(string pass)
    {
        bool changed = false;
        StringBuilder sb = new StringBuilder(pass);
        for(int i = 0; i < pass.Length && !changed; i++)
        {
            int index = Array.IndexOf(fCharList, sb[i]);
            if(index < fCharList.Length - 1)
            {
                for(int j = i - 1; j >= 0 && sb[j] == fCharList[fCharList.Length - 1]; j--)
                {
                   sb[j] = fCharList[0];
                }
                sb[i] = fCharList[index + 1];
                changed = true;
            }
        }
        if(!changed)
        {
            return "".PadLeft(pass.Length + 1, fCharList[0]);
        }
        return sb.ToString();
    }
