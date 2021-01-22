    public interface IListItem
    {
        IList<string> ExtraProperties;
    
    
        ... your old code.
    }
    
    public class User : IListItem
    {
       .. your old code
        public IList<string> ExtraProperties { return new List { "UserSpecificField" } }
    }
