    if (res == ResultType.Failure)               
    {
      something = ProcessFailure(..);
    }
    if (res == ResultType.ScheduledAndMonitored) 
    {
      something = DoSomething(...) && DoSomething3(..); //Bit-and on the results? huh.
    }
    if (res == ResultType.MoreInfoAvailable)     
    {
      info = GetInfo(..);
    }
    if (res == ResultType.OK && 
        someCondition)   
    {
      something = DoSomething2(..);
    }
