    public static bool ApplicationIsInEditMode(Application application)
    {
        try
        {
            application.ReferenceStyle = application.ReferenceStyle;
        }
        catch (COMException e)
        {
            return true;
        }
        return false;
    }
