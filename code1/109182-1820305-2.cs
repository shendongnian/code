      List<Control> text_controls = new List<Control>();
      FindAllControls(this.Controls, text_controls);
      private void FindAllControls(Control.ControlCollection controls, List<Control> ctrlsWithTextProperty)
      {
         foreach(Control ctrl in controls)
         {
            if(ctrl.GetType().GetProperty("Text") != null)
            {
               ctrlsWithTextProperty.Add(ctrl);
            }
            if (ctrl.Controls != null)
            {
               FindAllControls(ctrl.Controls, ctrlsWithTextProperty);
            }
         }
      }
