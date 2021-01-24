    String st = "85.78";
    Double db = Convert.ToDouble(st);
    //Or With Error Hndler
    try
            {
                string st = "85.78";
                Double db = Convert.ToDouble(st);
            }
    catch (FormatException)
            {
                // Your error handler 
          
            }
