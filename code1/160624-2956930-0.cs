    public class Helper 
    { 
       public static bool IsCurrentAppWeb; //defaults to false
       public bool TheActualHelpFullFunction()
       {
           if(Helper.IsCurrentAppWeb)
           {
               //do web specific things
           }
           else
           {
               //do things the non-web way.
               //note that this does not tell you 
               //if you are currently running a WinForm or service or...
           }
       }
    }
