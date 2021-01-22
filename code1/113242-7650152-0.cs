        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            tp.AutoPopDelay = 5000;
            tp.InitialDelay = 0;
            tp.ReshowDelay = 500;
            tp.ShowAlways = true;
            //Gets or sets whether the tooltip should use a ballon window
            tp.IsBalloon = true;
            
            tp.SetToolTip(this.textBox1, "This is a Text");
            tp.SetToolTip(this.button1, "This is a button");
        }
