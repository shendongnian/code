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
                
                // Initialize some sample data.
                data = new List<SomeObject>
                {
                    new SomeObject("Alice"),
                    new SomeObject("Bob"),
                    new SomeObject("Carol"),
                };
                
                // Bind the "complex" control to the sample data.
                complexBindingControl1.DataSource = data;
                
                // Bind the "lookup" control to the sample data.
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
