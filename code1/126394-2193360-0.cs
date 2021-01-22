      public ReturnEnum ConvertEnum<InEnum, ReturnEnum>(InEnum fromEnum)
      {
         ReturnEnum ret = (ReturnEnum)Enum.ToObject(typeof(ReturnEnum), fromEnum);
         if (Enum.IsDefined(typeof(ReturnEnum), ret))
         {
            return ret;
         }
         else
         {
            throw new Exception("Nope"); // TODO: Create more informative error here
         }
      }
