    public class C : InputBase, IHaveInputBase
    {
        IList<InputBase> IHaveInputBase.Inputs { get; set; }
    }
    public class Service
    {
        public void Handle(InputBase inputBase)
        {
            IHaveInputBase haveInputBase = inputBase as IHaveInputBase;
            
            if (haveInputBase != null)
            {
                foreach (InputBase input in haveInputBase.Inputs) 
                {
                    this.Handle(input);
                }
            }
            inputBase.DateCreated = this.dateTimeService.UtcNow();
            ...
        }
    }
