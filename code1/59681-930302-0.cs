    using System;
    using System.Windows.Forms;
    using System.Drawing;
    
    class Test
    {   
        [STAThread]
        static void Main(string[] args)
        {
            Button button = new Button 
            {
                Text = "Toggle border",
                AutoSize = true,
                Location = new Point(20, 20)
            };
            Form form = new Form
            {
                Size = new Size (200, 200),
                Controls = { button },
                FormBorderStyle = FormBorderStyle.Fixed3D
            };
            button.Click += ToggleBorder;
            Application.Run(form);
        }
        
        static void ToggleBorder(object sender, EventArgs e)
        {
            Form form = ((Control)sender).FindForm();
            form.FormBorderStyle = form.FormBorderStyle == FormBorderStyle.Fixed3D
                ? FormBorderStyle.Sizable : FormBorderStyle.Fixed3D;
        }
    }
