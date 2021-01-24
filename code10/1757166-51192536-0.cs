    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace _51189773
    {
        public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
                ListBox lb = new ListBox();
                lb.Items.Add("result 1");
                lb.Items.Add("result 2");
                lb.Items.Add("result 3");
                Controls.Add(lb);
            }
        }
    }
    
