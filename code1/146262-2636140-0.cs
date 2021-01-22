      [Designer(typeof(NavigationalUserControl.Designer))]
      public partial class NavigationalUserControl : UserControl
      {
        class Designer : ControlDesigner 
        {
          public override void Initialize(IComponent component)
          {
            base.Initialize(component);
            var nc = component as NavigationalUserControl;
            EnableDesignMode(nc.panel2, "ContainerPanel"); 
            EnableDesignMode(nc.bottomPanel, "BottomPanel");
          }
        }
    
        // rest of normal class
      }
