    public void SomeMethod()
    {
       try
       {
            // Some code that might throw an exception
       }
       catch (Exception ex)
       {
            throw new MyCustomException("Additional error information", ex);
       }
    }
