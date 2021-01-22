    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double x;
        double y;
        string operation;
        double memory;
        string current;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                textBox1.Text = button1.Text;
            }
            
            else
            {
                textBox1.Text += button1.Text;
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                textBox1.Text = button13.Text;
            }
            
            else
            {
                textBox1.Text += button13.Text;
            }
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                textBox1.Text = button6.Text;
            }
            
            else
            {
                textBox1.Text += button6.Text;
            }
            
        }
        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                textBox1.Text = button16.Text;
            }
          
            else
            {
                textBox1.Text += button16.Text;
            }
           
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                textBox1.Text = button9.Text;
            }
           
            else
            {
                textBox1.Text += button9.Text;
            }
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                textBox1.Text = button3.Text;
            }
          
            else
            {
                textBox1.Text += button3.Text;
            } 
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                textBox1.Text = button10.Text;
            }
        
            else
            {
                textBox1.Text += button10.Text;
            } 
            
            
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                textBox1.Text = button15.Text;
            }
           
            else
            {
                textBox1.Text += button15.Text;
            }
           
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                textBox1.Text = button8.Text;
            }
          
            else
            {
                textBox1.Text += button8.Text;
            }
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                textBox1.Text = button4.Text;
            }
            else
            {
                textBox1.Text += button4.Text;
            }
            
            
        }
        private void Plus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                x = Convert.ToDouble(textBox1.Text);
                operation = Plus.Text;
            }
            else
            {
                x = Convert.ToDouble(textBox1.Text);
                operation = Plus.Text;
                textBox1.Text = "";
            }
        }
        private void MINUS_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                x = Convert.ToDouble(textBox1.Text);
                operation = MINUS.Text;
            }
            else
            {
                x = Convert.ToDouble(textBox1.Text);
                operation = MINUS.Text;
                textBox1.Text = "";
            }
        }
        private void Times_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                x = Convert.ToDouble(textBox1.Text);
                operation = Times.Text;
            }
            else
            {
                x = Convert.ToDouble(textBox1.Text);
                operation = Times.Text;
                textBox1.Text = "";
            }
        }
        private void DIVIDE_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                x = Convert.ToDouble(textBox1.Text);
                operation = DIVIDE.Text;
            }
            else
            {
                x = Convert.ToDouble(textBox1.Text);
                operation = DIVIDE.Text;
                textBox1.Text = "";
            }
        }
        private void button24_Click(object sender, EventArgs e)
        {
            y = Convert.ToDouble(textBox1.Text);
            if (operation == Plus.Text)
            {
                textBox1.Text = Convert.ToString(x + y);
            }
            else if (operation == MINUS.Text)
            {
                textBox1.Text = Convert.ToString(x - y);
            }
            else if (operation == Times.Text)
            {
                textBox1.Text = Convert.ToString(x * y);
            }
            else if (operation == DIVIDE.Text)
            {
                textBox1.Text = Convert.ToString(x / y);
            }
        }
        private void button25_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }
        private void button27_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0.";
        }
        private void button26_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0.";
            operation = Convert.ToString(ConsoleCancelEventArgs.Empty);
        }
        private void button21_Click(object sender, EventArgs e)
        {
            x = Convert.ToDouble(textBox1.Text);
            textBox1.Text = Convert.ToString(Math.Sqrt(x));
        }
        private void button19_Click(object sender, EventArgs e)
        {
            x = Convert.ToDouble(textBox1.Text);
            textBox1.Text = Convert.ToString(1 / x);
        }
        private void button20_Click(object sender, EventArgs e)
        {
            y = Convert.ToDouble(textBox1.Text);
            textBox1.Text = Convert.ToString(x * (y / 100));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            x = Convert.ToDouble(textBox1.Text);
            if (textBox1.Text == "0.")
            {
                textBox1.Text = textBox1.Text;
            }
            else
            {
                textBox1.Text = Convert.ToString(-1 * x);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0.")
            {
                textBox1.Text = button5.Text;
            }
            else
            {
                textBox1.Text += button5.Text;
            }
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current = textBox1.Text;
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Paste(current);
        }
        private void aboutUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        
        }
        private void button18_Click(object sender, EventArgs e)
        {
            memory = 0;
            textBox1.Text = "0.";
        }
        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(memory);
        }
        private void button17_Click(object sender, EventArgs e)
        {
            memory = 0;
            memory += Convert.ToDouble(textBox1.Text);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            memory += Convert.ToDouble(textBox1.Text);
        }
        
        private void digitGroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (digitGroupingToolStripMenuItem.Checked)
            {
                NumberFormatInfo nFI = new CultureInfo("en-US", false).NumberFormat;
                double int_value = Convert.ToDouble(textBox1.Text);
                textBox1.Text = int_value.ToString("N", nFI);
            }
            else
            {
                
            }
         }
      
       
        }
    }
