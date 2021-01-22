    namespace WindowsFormsApplication1
    {
        using System.Windows.Forms;
    
        public partial class BaseForm : Form
        {
            public BaseForm()
            {
                InitializeComponent();
    
                this.MaximumSize = this.MinimumSize = this.Size;
            }
        }
    }
