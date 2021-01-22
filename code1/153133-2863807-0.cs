    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;   // Note: add reference required
    
    namespace WindowsFormsApplication1 {
        [Designer(typeof(MyDesigner))]   // Note: custom designer
        public partial class UserControl1 : UserControl {
            public UserControl1() {
                InitializeComponent();
            }
            // Note: property added
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public ListView Employees { get { return listView1; } }
        }
  
        // Note: custom designer class added
        class MyDesigner : ControlDesigner {
            public override void Initialize(IComponent comp) {
                base.Initialize(comp);
                var uc = (UserControl1)comp;
                EnableDesignMode(uc.Employees, "Employees");
            }
        }
    }
