    using System.Drawing;
    using System.Windows.Forms;
    
    static class Program {
        static void Main()
        {
            Form form = new Form();
            Color start = Color.Red, end = Color.Khaki;
            for (int i = 0; i < 16; i++)
            {
                int r = Interpolate(start.R, end.R, 15, i),
                    g = Interpolate(start.G, end.G, 15, i),
                    b = Interpolate(start.B, end.B, 15, i);
    
                Button button = new Button();
                button.Dock = DockStyle.Top;
                button.BackColor = Color.FromArgb(r, g, b);
                form.Controls.Add(button);
                button.BringToFront();
            }
    
            Application.Run(form);
        }
        static int Interpolate(int start, int end, int steps, int count)
        {
            float s = start, e = end, final = s + (((e - s) / steps) * count);
            return (int)final;
        }    
    }
