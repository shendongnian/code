    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace formload
    {
        public partial class FormB : Form
        {
            public FormB()
            {
                InitializeComponent();
                myPropString = "Default set via constructor";
            }
    
            private void FormB_Load(object sender, EventArgs e)
            {
                myPropString = "Set from form load";
            }
    
            private string myPropString;
    
            public string MyProperty
            {
                get { return myPropString; }
                set { myPropString = value; }
            }
    	
        }
    }
