    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using E5KDAQCSHARP32;
    
    namespace TestE5KDA
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                int dival=0;
                int[] counterval = new int[23];
                // Test test1= new Test();
                Class1.E5K_ReadDIStatus(Module1.mid, ref dival);
    
                //read DI counter value
                Class1.E5K_ReadMultiDICounter(Module1.mid, 0, 2, counterval);
        for (int  i = 0; i<= Module1.mDIChannels -1; i++)
                {
                    //Module1. mDICounterlist(i).Text = counterval(i);
                    //Console.WriteLine(i);
                    MessageBox.Show(counterval[i].ToString());
                }
    
    
    
    
            }
    
        }
    }
