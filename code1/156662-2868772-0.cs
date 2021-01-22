    protected UserControl LoadControl(string UserControlPath, params object[] constructorParameters)
    {
        List<System.Type> constParamTypes = new List<System.Type>();
        foreach (object constParam in constructorParameters)
        {
            constParamTypes.Add(constParam.GetType());
        }
    
        UserControl ctl = Page.LoadControl(UserControlPath) as UserControl;
    
        // Find the relevant constructor
        ConstructorInfo constructor = ctl.GetType().BaseType.GetConstructor(constParamTypes.ToArray());
    
        //And then call the relevant constructor
      
    
          if (constructor == null)
            {
                throw new MemberAccessException("The requested constructor was not found on : " + ctl.GetType().BaseType.ToString());
            }
            else
            {
                constructor.Invoke(ctl, constructorParameters);
            }
    
            // Finally return the fully initialized UC
            return ctl;
        }
