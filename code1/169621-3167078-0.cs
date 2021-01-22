    public class WizardView
    {
         public List<string> Steps { get; set; }
         public int CurrentStepNumber {get;set;}
       
         public bool ShowNextButton
         {
             get
             {
                 return CurrentStepNumber < this.Steps.Count-1;
             }
         }  
    
         public bool ShowPreviousButton
         {
             get
             {
                 return CurrentStepNumber > 0;
             }
         }  
    }
