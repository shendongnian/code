    List<Exception> exs = new List<Exception>();
    try
    {
        
        foreach(var a in b)
        {
            try
            {
                //...some code
            }
            catch(Exception ex)
            {
                exs.Add(ex);
            }
            finally
            {
                //...some code
            }
        }        
    }    
    catch(Exception e)
    {
       Console.WriteLine(e.ToString());
    }
    finally
    {
        //...some code
    }
    exs.ForEach(ex=> Console.WriteLine(e.ToString()));
