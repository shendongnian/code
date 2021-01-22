    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
      public partial class Form1 : Form
      {
        private System.Windows.Forms.StatusStrip statusStrip2;
    
        public Form1()
        {
          InitializeComponent();
    
          this.statusStrip2 = new System.Windows.Forms.StatusStrip();
          this.SuspendLayout();
          this.statusStrip2.Location = new System.Drawing.Point(0, 251);
          this.statusStrip2.Name = "statusStrip2";
          this.statusStrip2.Size = new System.Drawing.Size(292, 22);
          this.statusStrip2.TabIndex = 0;
          this.statusStrip2.Text = "statusStrip2";
          this.Controls.Add(this.statusStrip2);
    
          this.PerformLayout();
        }
    
      }
    }
