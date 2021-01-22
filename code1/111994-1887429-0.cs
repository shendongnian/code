    class Api
    {
    ....
      private static ErrorCode  Method();//changing Method to private
    
      public static void NewMethod()//NewMetod is void, because error is converted to exceptions
      {
          ErrorCode result = Method();
          if (result != ErrorCode.SUCCESS) {
              throw Helper.ErrorToException(result);
      }
    
      }
    ....
    }
