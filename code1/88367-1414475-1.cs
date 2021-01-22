      bool IsValidDate(string value)
      {
         DateTime result;
         return DateTime.TryParse("...", out result); //result is stored, but you only care about the return value of TryParse()
      }
