        /// <summary>
    /// Function to convert the given bytes to either Kilobyte, Megabyte, or Gigabyte
    /// </summary>
    /// <param name="bytes">Double -> Total bytes to be converted</param>
    /// <param name="type">String -> Type of conversion to perform</param>
    /// <returns>Int32 -> Converted bytes</returns>
    /// <remarks></remarks>
    public static double ConvertSize(double bytes, string type)
    {
        try
        {
            const int CONVERSION_VALUE = 1024;
            //determine what conversion they want
            switch (type)
            {
                case "BY":
                     //convert to bytes (default)
                     return bytes;
                case "KB":
                     //convert to kilobytes
                     return (bytes / CONVERSION_VALUE);
                case "MB":
                     //convert to megabytes
                     return (bytes / CalculateSquare(CONVERSION_VALUE));
                case "GB":
                     //convert to gigabytes
                     return (bytes / CalculateCube(CONVERSION_VALUE));
                default:
                     //default
                     return bytes;
              }
         }
         catch (Exception ex)
         {
             Console.WriteLine(ex.Message);
             return 0;
          }
    }
    
    /// <summary>
    /// Function to calculate the square of the provided number
    /// </summary>
    /// <param name="number">Int32 -> Number to be squared</param>
    /// <returns>Double -> THe provided number squared</returns>
    /// <remarks></remarks>
    public static double CalculateSquare(Int32 number)
    {
         return Math.Pow(number, 2);
    }
    
    
    /// <summary>
    /// Function to calculate the cube of the provided number
    /// </summary>
    /// <param name="number">Int32 -> Number to be cubed</param>
    /// <returns>Double -> THe provided number cubed</returns>
    /// <remarks></remarks>
    public static double CalculateCube(Int32 number)
    {
         return Math.Pow(number, 3);
    }
    
    //Sample Useage
    String Size = "File is " + ConvertSize(250222,"MB") + " Megabytes in size"
