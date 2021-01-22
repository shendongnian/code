    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form3 : Form,IObserver
        {
            public Form3()
            {
                InitializeComponent();
            }
    
            private void Form3_Load(object sender, EventArgs e)
            {
    
            }
            void IObserver.Refresh(List<string> DisplayList)
            {
                this.comboBox1.Items.Clear();
                foreach (string s in DisplayList)
                {
                    this.comboBox1.Items.Add(s);
                }
                this.comboBox1.Refresh();
            }
        }
    }
