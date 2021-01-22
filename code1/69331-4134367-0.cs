      public static void ForceVisibleState(Control control, bool visible)
      {
         if (!visible)
         {
            control.Visible = false;
         }
         else
         {
            // Must set all parents to 'visible = true'
            List<Control> parents = new List<Control>();
            while (control != null &&
                   !control.Visible)
            {
               parents.Insert(0, control);
               control = control.Parent;
            }
            foreach(Control parent in parents)
            {
               parent.Visible = true;
            } 
         }
      }
