    if (res == ResultType.Failure)               
    {
      something = ProcessFailure(..);
    }
    
    if (res == ResultType.ScheduledAndMonitored) 
    {
      something = DoSomething(...) && DoSomething3(..);
    }
    
    if (res == ResultType.MoreInfoAvailable)     
    {
      info = GetInfo(..);
    }
    
    if (res == ResultType.OK && someCondition)   
    {
      something = DoSomething2(..);
    }
