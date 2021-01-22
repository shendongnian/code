     public void DoSomething(string parameterA, int parameterB)
     {
     } 
    
     public void Helper(dynamic parameter)
     {
         DoSomething(parameter.Parameter1, parameter.Parameter2);
     }
    
     var parameters = new {Parameter1="lifeUniverseEverything", Parameter2=42};
    
     Helper(parameters);
