    [Serializable]
    public class Failure: Exception
    {
        public string ErrorMessage
        {
          get
           {
             return base.Message.ToString();
           }
        }
   
    }
