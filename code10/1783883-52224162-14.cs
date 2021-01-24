    public static void Mainfunction()
    {
        try
        {
            //some code
            //some code
            Exception ex = null;
            Subfunction( ref ex );
            if( ex == null ) 
            {
                ThirdFunction();
            }
        }
        catch(Exception ex)
        {
            //write to log
        }
    }
    public static void Subfunction( ref Exception outEx )
    {
        try
        {
            //some code
            //some code
        }
        catch (Exception ex)
        {
            outEx = ex;
        }
    }
