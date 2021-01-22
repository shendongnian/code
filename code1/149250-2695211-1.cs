        using System.ComponentModel;
        using System.Windows.Forms;
        using System.Windows.Forms.Design;
    
        namespace MyCtrlLib
        {
            // specify my custom designer
            [Designer(typeof(MyCtrlLib.UserControlDesigner))]
            public partial class UserControl1 : UserControl
            {
                public UserControl1()
                {
                    InitializeComponent();
                }
        
                // define a property called "DropZone"
                [Category("Appearance")]
                [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] 
                public Panel DropZone
                {
                    get { return panel1; }
                }
            }
        
            // my designer
            public class UserControlDesigner  : ParentControlDesigner
            {
                public override void Initialize(System.ComponentModel.IComponent component)
                {
                    base.Initialize(component);
        
                    if (this.Control is UserControl1)
                    {
                        this.EnableDesignMode((
                           (UserControl1)this.Control).DropZone, "DropZone");
                    }
                }
            }
        }
