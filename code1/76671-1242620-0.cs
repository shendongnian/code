    public partial class YourEntity
    {
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if(action == System.Data.Linq.ChangeAction.Insert)
               // Do insert
            ... etc. ...
        }
    }
