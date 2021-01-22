    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            int clickCount = 0;
    
            public Form1()
            {
                InitializeComponent();
                label1.SetText("0");
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                new Thread(() => label1.SetText((++clickCount).ToString())).Start();
            }
        }
    
        public static class ControlExtensions
        {
            public static void SetText(this Control control, string text)
            {
                if (control.InvokeRequired)
                    control.Invoke(setText, control, text);
                else
                    control.Text = text;
            }
    
            private static readonly Action<Control, string> setText =
                (control, text) => control.Text = text;
        }
    }
