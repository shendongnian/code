    using System;
    using System.Windows.Forms;
    using BlackFox.Win32;
    using System.Drawing;
    
    class Program
    {
        static void Main(string[] args)
        {
            PictureBox pict = new PictureBox();
            pict.Image = Icons.IconFromExtension(".zip", Icons.SystemIconSize.Large).ToBitmap();
            pict.Dock = DockStyle.Fill;
            pict.SizeMode = PictureBoxSizeMode.CenterImage;
    
            Form form = new Form();
            form.Controls.Add(pict);
    
            Application.Run(form);        
        }
    }
