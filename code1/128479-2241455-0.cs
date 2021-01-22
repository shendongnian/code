    public class FormView : System.Web.UI.WebControls.FormView
    {
      [Browsable(false), 
      DefaultValue((string)null), 
      PersistenceMode(PersistenceMode.InnerProperty), 
      TemplateContainer(typeof(FormView), BindingDirection.TwoWay),
      TemplateInstance(TemplateInstance.Single)]
      public override ITemplate EditItemTemplate
      {
        get { return base.EditItemTemplate; }
        set { base.EditItemTemplate = value; }
      }
    }
