    public void MyFunc1()
    {
      try
      {
        // some code here that eventually throws an exception
      }
      catch( Exception ex )
      {
         Helper(ex);
      }
    }
    private void Helper(Exception ex = null)
    {
        // result of a thrown exception here.
        if (ex!=null)
        {
            // do things.
        } else {
            // do other things
        }
    }
