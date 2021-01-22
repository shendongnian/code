    public class EntityBase
    {
        protected virtual void Create(EntityBase c)
        {
            Log.BeginRequest(c, ActionType.Create);
            Validate(c);
            WebService.Send(Convert(c));
            Log.EndRequest(c, ActionType.Create); 
        }
    }
    
