    public abstract class EntityBase
    {
        protected abstract void Validate();
    
        protected void Create(EntityBase c)
        {
            Log.BeginRequest(c, ActionType.Create);
            c.Validate();
            WebService.Send(Convert(c));
            Log.EndRequest(c, ActionType.Create); 
        }
    }
    
