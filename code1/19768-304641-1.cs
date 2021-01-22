    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsApplication
    {
        public partial class BusinessEditor : Form
        {
            private EventHandler<EventArgs> businessDeletedHandler;
    
            public BusinessEditor(Business business)
                : this()
            {
                InitializeComponent();
    
                businessBindingSource.DataSource = business;
    
                // Registering
                businessDeletedHandler = new EventHandler<EventArgs>(business_Deleted);
                business.Deleted += businessDeletedHandler;
            }
    
            void business_Deleted(object sender, EventArgs e)
            {
                MessageBox.Show("Item has been deleted in another editor window.",
                    "...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
    
            private void deleteButton_Activate(object sender, EventArgs e)
            {
                Business c = (Business)businessBindingSource.DataSource;
                // Unregistering
                c.Deleted -= businessDeletedHandler;
                c.Delete();
                Close();
            }
        }
    }
