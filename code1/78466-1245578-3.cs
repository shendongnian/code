     public static ISomeEntity DisplayEntity(ISomeEntity display)
    {
    
             ISomeEntity result;
               if (entity is ADisplayEntity)
                {
                    ADisplay disp = new ADisplay();
                    result = disp.ADisplayFunc();
                }
              if(entity is BDisplayEntity)
               {
                    BDisplay disp = new BDisplay();
                    result = disp.BDisplayFunc();
               }
    
        return result;
    }
