    class UCDesigner : System.Windows.Forms.Design.ControlDesigner {
      public override System.Windows.Forms.Design.SelectionRules SelectionRules {
        get {
          return (base.SelectionRules & ~(SelectionRules.BottomSizeable | SelectionRules.TopSizeable));
        }
      }
    }
