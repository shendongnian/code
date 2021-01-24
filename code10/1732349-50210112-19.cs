    public static string IncreasePassword(string pass)
    {
        bool changed = false;
        StringBuilder sb = new StringBuilder(pass);
        // loop through pass until we change something 
        // or we reach the end (what comes first)
        for(int i = 0; i < pass.Length && !changed; i++)
      //for(int i = pass.Length - 1; i >= 0 && !changed; i--)  
        {
            int index = Array.IndexOf(fCharList, sb[i]);
            // if current char can be increased
            if(index < fCharList.Length - 1)
            {
                // if we have __012 then we'll go on 00112
                // so here we replace the left __ with 00
                for(int j = i - 1; j >= 0 && sb[j] == fCharList[fCharList.Length - 1]; j--)
              //for(int j = i + 1; j < sb.Length && sb[j] == fCharList[fCharList.Length - 1]; j++)
                {
                   sb[j] = fCharList[0];
                }
                // and here we increase the current char
                sb[i] = fCharList[index + 1];
                changed = true;
            }
        }
        // if we didn't change anything, it means every char were '_'
        // so we start with a fresh new full-of-0 string
        if(!changed)
        {
            return "".PadLeft(pass.Length + 1, fCharList[0]);
        }
        return sb.ToString();
    }
