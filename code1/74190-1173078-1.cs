    IEnumerable<Task> Tasks;
    
    foreach(var task in Tasks)
    {
       try
       {
         //boiler plate prep for task
       }
       catch(Exception ex)
       {
         LogTaskFailure(task);
         continue;
       }
       foreach(var step in task.Steps)
       {  
          try
          {
            step.Execute();
          }
          catch(Exception ex)
          {
            LogStepError(step, ex);
            LogTaskFailure(task);
            break;
          }
        }
    }
    
    class TaskStep
    {
        private void Execute()
        {
           //do some stuff, don't catch any exceptions
        }            
    }
