    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace Test
    {
        public class ComponentClass : Component
        {
            public ComponentClass()
            {
                MessageBox.Show("Runtime!");
            }
        }
    }
