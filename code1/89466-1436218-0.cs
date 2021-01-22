    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    
    using System.Runtime.InteropServices;
    
    namespace Bitwise
    {
        public partial class Form1 : Form
        {
    
            [System.Runtime.InteropServices.StructLayout(LayoutKind.Explicit)]
            struct TestUnion
            {
    
                [System.Runtime.InteropServices.FieldOffset(0)]
                public uint Number;
    
                [System.Runtime.InteropServices.FieldOffset(0)]
                public ushort Low;
    
                [System.Runtime.InteropServices.FieldOffset(2)]
                public ushort High;
            }
    
            public Form1()
            {
                InitializeComponent();    
   
                var x = new TestUnion { Number = 0xDEADBEEF };
    
    
                MessageBox.Show(string.Format("{0:X} {1:X} {2:X}",x.Number, x.High, x.Low));
            }
        }
    }
