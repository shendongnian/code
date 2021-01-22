    // class level
    List<Control> controls = new List<Control>();
    
    // put in code-behind class...
    private void GatherIControlInjectors(){
         foreach(Control ctrl in Master.Contols){
              if(ctrl is IControlInjector){
                  controls.Add(ctrl);
              }
              if(ctrl.Controls.Count > 0)
                  GatherIControlInjectors();
         }
         return;
    }
