    string MySessionVar
    {
       get{
          return Session("MySessionVar") ?? String.Empty;
       }
       set{
          Session("MySessionVar") = value;
       }
    }
