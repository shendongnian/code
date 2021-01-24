        Panel pan1 = new Panel();
        Panel pan2 = new Panel();
        Panel pan3 = new Panel();
        Panel pan4 = new Panel();
        private void Form1_Load(object sender, EventArgs e)
        {
           
            pan1.Name = "pan1";
            pan1.Location = new Point(0, 0);
            pan1.Size = new Size(100, 100);
            pan1.BackColor = Color.LightGray;
            pan1.Click += new EventHandler(this.Panel_Click);
            pan2.Name = "pan2";
            pan2.Location = new Point(110, 0);
            pan2.Size = new Size(100, 100);
            pan2.BackColor = Color.LightGray;
            pan2.Click += new EventHandler(this.Panel_Click);
            pan3.Name = "pan3";
            pan3.Location = new Point(220, 0);
            pan3.Size = new Size(100, 100);
            pan3.BackColor = Color.LightGray;
            pan3.Click += new EventHandler(this.Panel_Click);
            pan4.Name = "pan4";
            pan4.Location = new Point(330, 0);
            pan4.Size = new Size(100, 100);
            pan4.BackColor = Color.LightGray;
            pan4.Click += new EventHandler(this.Panel_Click);
            this.Controls.Add(pan1);
            this.Controls.Add(pan2);
            this.Controls.Add(pan3);
            this.Controls.Add(pan4);
        }
        private void Panel_Click(object sender , EventArgs e)
        {
            this.pan1.BackColor = Color.LightGray;
            this.pan2.BackColor = Color.LightGray;
            this.pan3.BackColor = Color.LightGray;
            this.pan4.BackColor = Color.LightGray;
            Panel pan = (Panel)sender;
            pan.BackColor = Color.Red;
        }
