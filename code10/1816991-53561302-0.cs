    using System;
    using System.Windows.Forms;
    using System.IO;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                string startupPath = Application.StartupPath;
                Console.WriteLine(startupPath); // .../MiProyecto/Socket/bin/Debug
    
                string folderName = "MiProyecto";
                DirectoryInfo di = new DirectoryInfo(startupPath);
    
                // Loop until found MiProyecto folder
                while (true)
                {
                    if (di.Parent.FullName.EndsWith(folderName))
                    {
                        break;
                    }
                    else
                    {
                        di = new DirectoryInfo(di.Parent.FullName);
                    }
                }
    
                Console.WriteLine(di.Parent.FullName); // .../MiProyecto
            }
        }
    }
