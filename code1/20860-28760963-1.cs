    public static char ToChar(this Keys key)
    {
        char c = '\0';
        if((key >= Keys.A) && (key <= Keys.Z))
        {
            c = (char)((int)'a' + (int)(key - Keys.A));
        }
        
        else if((key >= Keys.D0) && (key <= Keys.D9))
        {
            c = (char)((int)'0' + (int)(key - Keys.D0));
        }
        return c;
    }
