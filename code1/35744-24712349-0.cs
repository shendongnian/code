    public class Animal
    {
        public Action Run {get; set;}
    
        public void RaiseEvent()
        {
            if (Run != null)
            {
                Run();
            }
        }
    }
