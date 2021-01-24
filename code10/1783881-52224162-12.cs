    private static readonly int DONOTUSEMAGICNUMBERS = 1;
    public static int Subfunction()
    {
        int success = 0;
        try
        {
            //some code
            //some code
        }
        catch (Exception ex)
        {
            success = DONOTUSEMAGICNUMBERS;
        }
        return success;
    }
