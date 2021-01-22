      public static ISomeEntity DisplayEntity(ISomeEntity display)
        {
            IDisplay disp = Factory(display.GetType());
            ISomeEntity newDisplayEntity = disp.Display(display);
    
            return newDisplayEntity;
        }
