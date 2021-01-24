    using System;
    using System.Windows.Forms;
    
    namespace UIWriteOverhead
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            int[] getNumbers(int upperLimit)
            {
                int[] ReturnValue = new int[upperLimit];
    
                for (int i = 0; i < ReturnValue.Length; i++)
                    ReturnValue[i] = i;
    
                return ReturnValue;
            }
    
            void printWithBuffer(int[] Values)
            {
                textBox1.Text = "";
                string buffer = "";
    
                foreach (int Number in Values)
                    buffer += Number.ToString() + Environment.NewLine;
                textBox1.Text = buffer;
            }
    
            void printDirectly(int[] Values){
                textBox1.Text = "";
    
                foreach (int Number in Values)
                    textBox1.Text += Number.ToString() + Environment.NewLine;
            }
    
            private void btnPrintBuffer_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Generating Numbers");
                int[] temp = getNumbers(10000);
                MessageBox.Show("Printing with buffer");
                printWithBuffer(temp);
                MessageBox.Show("Printing done");
            }
    
            private void btnPrintDirect_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Generating Numbers");
                int[] temp = getNumbers(1000);
                MessageBox.Show("Printing directly");
                printDirectly(temp);
                MessageBox.Show("Printing done");
            }
        }
    }
