            public Form2()
            {
                InitializeComponent();
                t = textBox1;                        //Initialize with static textbox
            }
            public static TextBox t=new TextBox();   //make static to get the same value as inserted
            private void button1_Click(object sender, EventArgs e)
            {
                
                this.Close();
                
            }
