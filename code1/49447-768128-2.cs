    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                button1.Click += new EventHandler(button1_Click);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                tableLayoutPanel1.Controls.Clear();
                string[] results = { "Heads", "Tails" };
                int nCoins = Convert.ToInt32(coins.Value);
                Random random = new Random();
                for (int i = 0; i < nCoins; i++)
                {
                    ComboBox coin = new ComboBox();
                    coin.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
                    coin.Items.AddRange(results);
                    coin.SelectedIndex = random.Next(0, 2);
                    tableLayoutPanel1.Controls.Add(coin, 0, i);
                }
            }
    
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                this.ActiveControl = null;
            }
    
        }
    }
