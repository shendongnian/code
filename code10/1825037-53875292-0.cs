    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                WindowState = FormWindowState.Maximized;
                DirectoryInfo test = new DirectoryInfo(@"c:\temp\");
                FileInfo[] Files = test.GetFiles("*.pdf"); //Getting Text files
    
                var fileNames = Files.Select(f => Path.GetFileNameWithoutExtension(f.Name)).ToList();
                comboBox1.DataSource = fileNames;
                comboBox1.SelectedIndex = 1;
                timerset();
            }
    
    
            private void panel1_ControlAdded(object sender, ControlEventArgs e)
            {
    
            }
    
            public void axSetting()
            {
                axAcroPDF1.setShowToolbar(true);
                axAcroPDF1.setView("FitH");
                axAcroPDF1.setPageMode("none");
                axAcroPDF1.setShowScrollbars(true);
                axAcroPDF1.setLayoutMode("SinglePage");
                axAcroPDF1.Show();
            }
    
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                axAcroPDF1.LoadFile(@"c:\temp\" + comboBox1.Text + ".pdf");
                axAcroPDF1.src = @"c:\temp\" + comboBox1.Text + ".pdf";
                axSetting();
            }
    
            public void comboBoxSelect()
            {
                if (comboBox1.SelectedIndex < (comboBox1.Items.Count - 1))
                {
                    comboBox1.SelectedIndex += 1;
                }
                else
                {
                    comboBox1.SelectedIndex = 0;
                    DirectoryInfo test = new DirectoryInfo(@"c:\temp\");
                    FileInfo[] Files = test.GetFiles("*.pdf");
    
                    var fileNames = Files.Select(f => Path.GetFileNameWithoutExtension(f.Name)).ToList();
                    comboBox1.DataSource = fileNames;
                }
            }
    
            public void timerset()
            {
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 10000; // in miliseconds            
                timer1.Start();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                comboBoxSelect();
            }
        }
    }
