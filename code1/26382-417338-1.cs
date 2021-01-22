    ListView v = new ListView();
            public Form1()
            {
                InitializeComponent();
                v.Items.Add("Foo");
                v.Height = 30;
                v.Width = 50;
                this.button1.Controls.Add(v);
                v.MouseMove += new MouseEventHandler(v_MouseMove);
                v.BackColor = SystemColors.Info;
                
                this.button1.MouseMove += new MouseEventHandler(button1_MouseMove);
            }
    
            void v_MouseMove(object sender, MouseEventArgs e)
            {
                v.Location = new Point(v.Location.X + e.Location.X, v.Location.Y + e.Location.Y);
            }
    
            void button1_MouseMove(object sender, MouseEventArgs e)
            {
                v.Location = e.Location;
            }
