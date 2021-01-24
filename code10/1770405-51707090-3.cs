    using System;
    using System.Windows.Forms;
    
    namespace InputFormTest
    {
        public static class InputHandler
        {
            public static Form mainForm;
            public static RichTextBox debugBox;
    
            public static void OnButton1Click(object sender, EventArgs e)
            {
                debugBox.AppendText("Button1 Clicked \n");
            }
    
            public static void OnButton2Click(object sender, EventArgs e)
            {
                debugBox.AppendText("Button2 Clicked \n");
            }
    
            public static void OnNumUpDown1Changed(object sender, EventArgs e)
            {
                debugBox.AppendText($"Num value: {((NumericUpDown)sender).Value} \n");
            }
        }
    }
