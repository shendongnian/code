    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form,IObserver
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            private void Form2_Load(object sender, EventArgs e)
            {
    
            }
    
            void IObserver.Refresh(List<string> DisplayList)
            {
                this.listBox1.Items.Clear();
                foreach (string s in DisplayList)
                {
                    this.listBox1.Items.Add(s);
                }
                this.listBox1.Refresh();
            }
            
        }
    }
