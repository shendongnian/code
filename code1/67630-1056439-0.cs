using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            const string myDevice = @"vid_04d8pid_003f";
            string devPathName = @"\\\?\hid#vid_04d8pid_003f#62edf110800000#{4d1e55b2-f16f-11cf-88cb-001111000030}";
            Boolean test =devPathName.Contains(myDevice);
            MessageBox.Show("\n\tThe value of test: " + test.ToString());
        }
    }
}
