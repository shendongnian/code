    private int myfun()
    {
        int a = 100; //any number
        int b = 0;
        try
        {
            a = (5 / b);
            return a;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            return a;
        }
     //   Response.Write("Statement after return before finally");  -->this will give error "Syntax error, 'try' expected"
        finally
        {
          Response.Write("Statement after return in finally"); // --> This will execute , even after having return code above
        } 
        
        Response.Write("Statement after return after finally");  // -->Unreachable code
    }
