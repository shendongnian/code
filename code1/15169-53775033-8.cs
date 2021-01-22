    // Form1.cs
    
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace BindingDemo
    {
        public partial class Form1 : Form
        {
            private readonly List<SomeObject> data;
            
            public Form1()
            {
                InitializeComponent();
                
                // Prepare some sample data.
                data = new List<SomeObject>
                {
                    new SomeObject("Alice"),
                    new SomeObject("Bob"),
                    new SomeObject("Carol"),
                };
                
                // Bind the data to your custom control...
                
                // ...for "complex" data binding:
                complexBindingControl1.DataSource = data;
                
                // ...for "lookup" data binding:
                lookupBindingControl1.DataSource = data;
                lookupBindingControl1.DisplayMember = "Name";
                lookupBindingControl1.ValueMember = "Name";
            }
        }
        
        internal class SomeObject
        {
            public SomeObject(string name)
            {
                Name = name;
            }
            
            public string Name { get; set; }
        }
    }
