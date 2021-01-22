    using System;
    using System.Windows.Forms;
    
    public class Hello
    {
        [STAThread]
        static void Main()
        {
            Form form = new Form
            {
                Text = "Simple Windows Forms app",
                Controls = { new Label { Text = "Hello, world" } }
            };
            Application.Run(form);
        }
    }
