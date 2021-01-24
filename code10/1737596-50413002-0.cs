    public class C
    {
        public IList<InputBase> Inputs {get; set;}
    }
    ...
    foreach (InputBase input in c.Inputs) 
    {
        input.DateCreated = this.dateTimeService.UtcNow();
        this.HandleInput(input);
    }
