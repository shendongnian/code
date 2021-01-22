    try
    {
       FileStream fs = null;
       try
       {
            fs = File.Open("Foo.txt", FileMode.Open))
            //Do Stuff
       }
       finally
       {
          if(fs != null)
              fs.Dispose();
       }
    }
    catch(Exception)
    {
       /// Handle Stuff
    }
