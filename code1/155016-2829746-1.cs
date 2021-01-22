    public class AbstractStep
    {
        public AbstractStep NextStep { get; set; }
    
        public virtual bool ExecuteStep
        {
           if (NextStep != null)
           {
             return NextStep.ExecuteStep();
           }
        }  
    }
    
    public class ConcreteStep1 : AbstractStep
    {
        public bool ExecuteStep
        {
           // execute DoProcess1 stuff
           // call base
           return base.ExecuteStep();
        }
    }
    
    ...
    
    public class ConcreteStep3 : AbstractStep
    {
         public bool ExecuteStep
         { 
            // Execute DoProcess3 stuff
            // call base
            return true; // or false?
          }
    }
