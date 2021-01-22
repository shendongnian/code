    public void Foo()
    {
      try
      {
        HelperMethod("value 1");
        return; // finished
      }
      catch (Exception e)
      {
         // possibly log exception
      }
      try
      {
        HelperMethod("value 2");
        return; // finished
      }
      catch (Exception e)
      {
         // possibly log exception
      }
      // ... more here if needed
    }
