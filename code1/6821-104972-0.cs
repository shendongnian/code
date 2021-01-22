    using System.Text.RegularExpressions;
     /// <summary>
      /// Validate that a string is a valid GUID
      /// </summary>
      /// <param name="GUIDCheck"></param>
      /// <returns></returns>
      private bool IsValidGUID(string GUIDCheck)
      {
       if (!string.IsNullOrEmpty(GUIDCheck))
       {
        return new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$").IsMatch(GUIDCheck);
       }
       return false;
      }
