    public partial class MyTable{
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            LastEditTime = DateTime.Now;
        }
    }
