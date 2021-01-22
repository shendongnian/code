    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    
    namespace WindowsFormsApplication1
    {
        [Designer(typeof(BaseFormDesigner), typeof(IRootDesigner))]
        public class BaseForm : Form
        {
            public BaseForm()
            {
            }
        }
    
        public class BaseFormDesigner : DocumentDesigner
        {
            public override void Initialize(IComponent component)
            {
                base.Initialize(component);
                var service = GetService(typeof(IComponentChangeService)) as IComponentChangeService;
                service.ComponentAdded += service_ComponentAdded;
            }
    
            private void service_ComponentAdded(object sender, ComponentEventArgs e)
            {
                if (e.Component is Control && !(e.Component is Form)) {
                    var control = (Control)e.Component;
                    if (!control.Name.StartsWith("_")) {
                        var service = GetService(typeof(IComponentChangeService)) as IComponentChangeService;
                        PropertyDescriptor desc = TypeDescriptor.GetProperties(control)["Name"];
                        service.OnComponentChanging(e.Component, desc);
                        string oldValue = control.Name;
                        string newValue = "_" + oldValue;
                        desc.SetValue(control, newValue);
                        service.OnComponentChanged(e.Component, desc, oldValue, newValue);
                    }
                }
            }
        }
    }
