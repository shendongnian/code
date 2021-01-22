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
        public partial class Form1 : Form
        {
            private List<string> DataList= new List<string>();
            private ObserverList MyObservers = new ObserverList();
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 frmNewForm = new Form2();
                MyObservers.Add(frmNewForm);
                frmNewForm.Show();
                MyObservers.Refresh(DataList);
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                Form3 frmNewForm = new Form3();
                MyObservers.Add(frmNewForm);
                frmNewForm.Show();
                MyObservers.Refresh(DataList);
    
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                DataList.Add(textBox1.Text);
                MyObservers.Refresh(DataList);
                textBox1.Text = "";
            }
    
        }
    }
