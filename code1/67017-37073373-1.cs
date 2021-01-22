     >I advise to not depend on ready made and built in code in .NET
     >framework , try to bring up new solution ..this is what i do.. 
    public  bool isAlphaNumeric(string N)
    {
        bool YesNumeric = false;
        bool YesAlpha = false;
        bool BothStatus = false;
        for (int i = 0; i < N.Length; i++)
        {
            if (char.IsLetter(N[i]) )
                YesAlpha=true;
            if (char.IsNumber(N[i]))
                YesNumeric = true;
            
        }
        if (YesAlpha==true && YesNumeric==true)
        {
            BothStatus = true;
        }
        else
        {
            BothStatus = false;
        }
        return BothStatus;
    }
