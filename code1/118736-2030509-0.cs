    public class MyCustomServerControl : CompositeControl
    {
       private Label labelTitle;
       private Panel panelContent;
    
       public override CreateChildControls()
       {
          base.Controls.Clear();
        
          labelTitle = new Label();
          labelTitle.ID = "lblTitle";
    
          panelContent = new Panel();
          panelContent.ID = "pnlContent";
    
    
          this.Controls.Add(labelTitle);
          this.Controls.Add(panelContent);
       }
    
       [Browsable(true)]
       public string LabelCssClass
       {
          get 
          {
             EnsureChildControls();
             return labelTitle.CssClass; 
          }
          set 
          { 
             EnsureChildControls();
             labelTitle.CssClass = value; 
          }
       }
    
       [Browsable(true)]
       public string PanelContentCssClass
       {
          get 
          {
             EnsureChildControls();
             return panelContent.CssClass; 
          }
          set 
          { 
             EnsureChildControls();
             panelContent.CssClass = value; 
          }
       }
       ... 
    }
