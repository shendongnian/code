    XElement OrderStatus(q_order_status Request)
    {
      XElement Response;
      int result = 0;
      string Message = "";
      try
      { 
        result = DoSomething1();
        if (result != 0)
        {
          throw new DoSomethingException("DoSomething1 has failed!");
        }
        result = DoSomething2();
        if (result != 0)
        {
          throw new DoSomethingException("DoSomething2 has failed!");
        }
        result = DoSomething3();
        if (result != 0)
        {
          throw new DoSomethingException("DoSomething3 has failed!");
        }
        Message = "All tests has been passed.";
      }
      catch(DoSomethingException e)
      {
        Message = e.Message;
      }
      catch(Exception e)
      {
        Message = e.Message;
      }
      finally
      {
        Response =  new XElement("SomeTag", Message);
      }
      return Response;
    }
