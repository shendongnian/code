    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WaitCursorTwoForms
    {
       public partial class Form1 : Form
       {
          public Form1()
          {
             InitializeComponent();
          }
    
          private void ButtonClick(object sender, EventArgs e)
          {
             using(Form2 form2 = new Form2())
             {
                form2.ShowDialog(this);
             }
          }
       }
    }
