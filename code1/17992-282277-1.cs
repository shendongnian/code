    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace Test
    {
        public class ComponentClass : Component
        {
            public ComponentClass()
            {
                if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                {
                    MessageBox.Show("Runtime!");
                }
            }
        }
    }
