    public void Test()
    {
       bool hasException = false;
       statement1;
       try
       {
           statement2;
       }
       catch (Exception)
       {
           hasException = true;
       }
       finally
       {
           if(hasException)
               Test();
       }
    }
