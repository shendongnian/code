    // class level Property
    IList<Control> controls = new List<Control>();
    
    // put in code-behind class...
    private void GatherIControlInjectors(Control control){
         foreach(Control ctrl in Master.Contols){
              if(ctrl is IControlInjector){
                  controls.Add(ctrl);
              }
              if(ctrl.Controls.Count > 0)
                  GatherIControlInjectors(ctrl);
         }
         return;
    }
    // example
    IList<IControlInjector> ctrlInjectors = GatherIControlInjectors(Master);
