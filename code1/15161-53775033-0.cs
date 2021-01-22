    // ComplexBindingControl.cs
    // Adapted from https://docs.microsoft.com/visualstudio/data-tools/create-a-windows-forms-user-control-that-supports-complex-data-binding
    
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace BindingDemo
    {
        [ComplexBindingProperties("DataSource", "DataMember")]
        public partial class ComplexBindingControl : UserControl
        {
            public ComplexBindingControl()
            {
                InitializeComponent();
            }
            
            // Use a DataGridView for its complex data binding implementation.
            
            public object DataSource
            {
                get => dataGridView1.DataSource;
                set => dataGridView1.DataSource = value;
            }
            
            public string DataMember
            {
                get => dataGridView1.DataMember;
                set => dataGridView1.DataMember = value;
            }
        }
    }
