      private Screen GetCurrentScreen()
      {
         System.Drawing.Point centerPoint 
            = new System.Drawing.Point((int)(Left + Width / 2), (int)(Top + Height / 2));
         foreach (Screen s in Screen.AllScreens)
         {            
            if (s.Bounds.Contains(centerPoint))
               return s;
         }
         return null;
      }
