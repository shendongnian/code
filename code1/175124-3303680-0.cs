      System.IO.FileStream fs = null;
        try
        {
            fs = new System.IO.FileStream("C:\test.txt", System.IO.FileMode.Open);
            //do something with the file stream
        }
        catch (Exception exp)
        {
            //handle exceptions
        }
        finally
        {
            //ERROR: "unassigned local variable fs"
            if (fs != null)
            {
                fs.Close();
            }
        }
