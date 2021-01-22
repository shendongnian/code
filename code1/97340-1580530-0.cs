    partial class Customer
    {
      string name;
      public string Name
      {
        get
        {
          return name;
        }
        set
        {
          OnBeforeUpdateName();
          OnUpdateName();
          name = value;
          OnAfterUpdateName();
        }
      }
      partial void OnBeforeUpdateName();
      partial void OnAfterUpdateName();
      partial void OnUpdateName();
    }
