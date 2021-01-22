    using System;
    using System.Windows.Forms;
    
    namespace AutoComplete
    {
        public partial class TestForm : Form
        {
            private readonly String[] _values = { "one", "two", "three", "tree", "four", "fivee" };
    
            public TestForm()
            {
                InitializeComponent();
                // AutoComplete is our special textbox control on the form
                AutoComplete.Values = _values;
            }
    
        }
    }
