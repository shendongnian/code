        try
        {
            FileStream fs = null;
            try
            {
               fs = File.Open("Foo.txt", FileMode.Open);
            }
            finally
            {
               fs.Dispose();
            }
        }
        catch(Exception)
        {
           /// Handle Stuff
        }
