    // LookupBindingControl.cs
    // Adapted from https://docs.microsoft.com/visualstudio/data-tools/create-a-windows-forms-user-control-that-supports-lookup-data-binding
    
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace BindingDemo
    {
        [LookupBindingProperties("DataSource", "DisplayMember", "ValueMember", "LookupMember")]
        public partial class LookupBindingControl : UserControl
        {
            public LookupBindingControl()
            {
                InitializeComponent();
            }
            
            // Use a ListBox or ComboBox for its lookup data binding implementation.
            
            public object DataSource
            {
                get => listBox1.DataSource;
                set => listBox1.DataSource = value;
            }
            
            public string DisplayMember
            {
                get => listBox1.DisplayMember;
                set => listBox1.DisplayMember = value;
            }
            
            public string ValueMember
            {
                get => listBox1.ValueMember;
                set => listBox1.ValueMember = value;
            }
            
            public string LookupMember
            {
                get => listBox1.SelectedValue.ToString();
                set => listBox1.SelectedValue = value;
            }
        }
    }
