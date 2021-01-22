       /// <summary>
       ///   Formats a string of nine digits into a U.S. phone number.
       /// </summary>
       /// <param name="value">
       ///   The string to format as a phone number.
       /// </param>
       /// <returns>
       ///   The numeric string as a U.S. phone number.
       /// </returns>
       public static string
       ToUSPhone (this string value)
       {
          if (value == null)
          {
             return null;
          }
    
          long  dummy;
    
          if ((value.Length != 10) ||
             !long.TryParse (
                value,
                NumberStyles.None,
                CultureInfo.CurrentCulture,
                out dummy))
          {
             return value;
          }
    
          return string.Format (
             CultureInfo.CurrentCulture,
             "{0}-{1}-{2}",
             value.Substring (0, 3),
             value.Substring (3, 3),
             value.Substring (6));
       }
