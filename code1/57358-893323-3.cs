    public override MetaObject GetMember(GetMemberAction action, MetaObject[] args)
    {
         //not sure on the real property name here...
         string actionName = action.Name;
    
         if (actionName = "Selected" + typeof(T).Name)
         {
              return SelectedItem; //in some MetaObject wrapper 
         }
    }
