    public static void Main()
    {
        // This item is obfuscated and can not be translated.
        int VB$ResumeTarget;
        try
        {
            int VB$CurrentStatement;
        Label_0001:
            ProjectData.ClearProjectError();
            int VB$ActiveHandler = -2;
        Label_0009:
            VB$CurrentStatement = 2;
            int i = 0;
        Label_000E:
            VB$CurrentStatement = 3;
            int y = (int) Math.Round((double) (5.0 / ((double) i)));
            goto Label_008F;
        Label_0029:
            VB$ResumeTarget = 0;
            switch ((VB$ResumeTarget + 1))
            {
                case 1:
                    goto Label_0001;
    
                case 2:
                    goto Label_0009;
    
                case 3:
                    goto Label_000E;
    
                case 4:
                    goto Label_008F;
    
                default:
                    goto Label_0084;
            }
        Label_0049:
            VB$ResumeTarget = VB$CurrentStatement;
            switch (((VB$ActiveHandler > -2) ? VB$ActiveHandler : 1))
            {
                case 0:
                    goto Label_0084;
    
                case 1:
                    goto Label_0029;
            }
        }
        catch (object obj1) when (?)
        {
            ProjectData.SetProjectError((Exception) obj1);
            goto Label_0049;
        }
    Label_0084:
        throw ProjectData.CreateProjectError(-2146828237);
    Label_008F:
        if (VB$ResumeTarget != 0)
        {
            ProjectData.ClearProjectError();
        }
    }
