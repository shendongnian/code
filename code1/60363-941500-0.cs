    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class Test
    {       
        [STAThread]
        static void Main(string[] args)
        {
            Form form = new Form();
            GroupBox group = new GroupBox();
            group.Text = "Text";
            group.ForeColor = Color.Red;
            form.Controls.Add(group);
            Application.Run(form);
        }
    }
