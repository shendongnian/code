    public static void Mainfunction()
    {
        try
        {
            //some code
            //some code
            ISuccessIndicator success = new ISIImplementation();
            Subfunction( success );
            if( !succes.HasException ) 
            {
                ThirdFunction();
            }
        }
        catch(Exception ex)
        {
            //write to log
        }
    }
    public static void Subfunction( ISuccessIndicator result )
    {
        try
        {
            //some code
            //some code
        }
        catch (Exception ex)
        {
            result.HasException=true;
            result.Exception = ex;
        }
    }
    public interface ISuccessIndicator 
    {
        Exception Exception {get; set;}
        bool HasException {get; set;}
    }
