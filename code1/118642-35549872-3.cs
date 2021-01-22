    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms.Design;
    [Designer(typeof(MyComponentDesigner))]
    public class MyComponent : Component
    {
        public string SomeProperty { get; set; }
    }
    public class MyComponentDesigner : ComponentDesigner
    {
        DesignerVerbCollection verbs;
        public MyComponentDesigner() : base() { }
        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (verbs == null)
                {
                    verbs = new DesignerVerbCollection();
                    verbs.Add(new DesignerVerb("Rename", (s, e) =>
                    {
                        try
                        {
                            this.Component.Site.Name = "SomeName";
                            this.RaiseComponentChanged(null, null, null);
                        }
                        catch (Exception ex)
                        {
                            var svc = ((IUIService)this.GetService(typeof(IUIService)));
                            svc.ShowError(ex);
                        }
                    }));
                }
                return verbs;
            }
        }
    }
