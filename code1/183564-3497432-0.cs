    using System;
    using System.Windows.Forms;
    
    public class Test
    {
        [STAThread]
        static void Main()
        {
            Button button = new Button { Text = "Click" };
            Form form = new Form
            {
                Controls = { button },
                FormBorderStyle = FormBorderStyle.None,
            };
            button.Click += delegate { form.Close(); };
            
            Application.Run(form);
        }
    }
