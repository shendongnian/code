    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class Test
    {
        static void Main()
        {
            
            TextBox tb = new TextBox();
            Button button = new Button
            {
                Location = new Point(0, 30),
                Text = "New form"
            };
            button.Click += (sender, args) =>
            {
                string name = tb.Text;
                Form f = new Form();
                f.Controls.Add(new Label { Text = name });
                f.Activated += (s, a) => Console.WriteLine("Activated: " + name);
                f.GotFocus += (s, a) => Console.WriteLine("GotFocus: " + name);
                f.Show();
                f.Controls.Add(new TextBox { Location = new Point(0, 30) });
            };
    
            Form master = new Form { Controls = { tb, button } };
            Application.Run(master);
        }
    }
