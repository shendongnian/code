     /// <summary>
     /// Prepares a byte array that hold EXIF latitude/longitude data
     /// </summary>
     /// <param name="degrees">There are 360° of longitude (180° E ↔ 180° W) and 180° of latitude (90° N ↔ 90° S)</param>
     /// <param name="minutes">Each degree can be broken into 60 minutes</param>
     /// <param name="seconds">Each minute can be divided into 60 seconds (”). For finer accuracy, fractions of seconds given by a decimal point are used. Seconds unit multiplied by 100. For example 33.77 seconds is passed as 3377. This gives adequate GPS precision</param>
     /// <returns></returns>
     private static byte[] FloatToExifGps(int degrees, int minutes, int seconds)
     {
          var secBytes = BitConverter.GetBytes(seconds);
          var secDivisor = BitConverter.GetBytes(100);
          byte[] rv = { (byte)degrees, 0, 0, 0, 1, 0, 0, 0, (byte)minutes, 0, 0, 0, 1, 0, 0, 0, secBytes[0], secBytes[1], 0, 0, secDivisor[0], 0, 0, 0 };
          return rv;
     }
