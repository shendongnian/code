    public string ProcessOrder(Order order)
    {
       if(order.IsValid)
       {
            System.Threading.ParameterizedThreadStart pts = new System.Threading.ParameterizedThreadStart(DoHardWork);
    
            System.Threading.Thread t = new System.Threading.Thread(pts);
            t.Start(order);
    
            return "Great!!!";
       }
    }
    
    public void DoHardWork(object order)
    {
    //Stuff Goes Here
    }
