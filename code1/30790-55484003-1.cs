C#
[Serializable]
public class CustomException: Exception
{
    public CustomException: ( Exception exception ) : base(exception.Message)
    {             
        Data.Add("StackTrace",exception.StackTrace);
    }      
}
To serialize your custom exception:
C#                                                       
JsonConvert.SerializeObject(customException);
