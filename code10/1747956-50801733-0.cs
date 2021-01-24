    public class MyControlTasks : System.ComponentModel.Design.DesignerActionList 
    {
      private MyControl myControl;
    
      private DesignerActionUIService designerActionUISvc = null;
    
      public MyControlTasks( IComponent component ) : base(component) 
      {
        this.myControl = component as MyControl;
        this.designerActionUISvc =
            GetService(typeof(DesignerActionUIService))
            as DesignerActionUIService;
      }
    }
