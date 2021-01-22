    string ProcessOrder(Order order)
    {
      if(order.IsValid)
      {
                //Starts a new thread
                ThreadPool.QueueUserWorkItem(th =>
                    {
                        //Process Order here
    
                    });
    
          return "Great!";
      }
    }
