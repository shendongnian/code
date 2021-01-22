    public static Control GetParentOfType(this Control childControl,
                                       Type parentType)
      {
          Control parent = childControl.Parent;
          while(parent.GetType() != parentType)
          {
              parent = parent.Parent;
          }
          if(parent.GetType() == parentType)
                return parent;
            
         throw new Exception("No control of expected type was found");
      }
