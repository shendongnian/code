    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    
    namespace WaitCursorTwoForms
    {
       public partial class Form2 : Form
       {
          public Form2()
          {
             Cursor.Current = Cursors.WaitCursor;
             InitializeComponent();
             for (int i = 0; i < 10; i++)
             {
                Thread.Sleep(1000);
             }
          }
    
          private void OnShown(object sender, EventArgs e)
          {         
             Cursor.Current = Cursors.Default;
          }
       }
    }
