    public partial class form_counterMain : Form
    {
        int[] b=new int[9]; //initialized the counters
        Button[] btn= new Button[9]; //initialized the buttons
        
            
        public form_counterMain()
        {
            for (int t = 0; t < 9; t++) //this loop makes all the counters 0
            {
                b[t] = 0;
            }
            for (int t = 0; t < 9;t++) //this loop makes all the buttons assigned to a button
            {
                btn[t]=new Button();
            }
            InitializeComponent();
            changeFunc(); //first calculation
            btn[0].Click += new System.EventHandler(btn0Click); //here i assign the functions to buttons
            btn[1].Click += new System.EventHandler(btn1Click);
            btn[2].Click += new System.EventHandler(btn2Click);
            btn[3].Click += new System.EventHandler(btn3Click);
            btn[4].Click += new System.EventHandler(btn4Click);
            btn[5].Click += new System.EventHandler(btn5Click);
            btn[6].Click += new System.EventHandler(btn6Click);
            btn[7].Click += new System.EventHandler(btn7Click);
            btn[8].Click += new System.EventHandler(btn8Click);
        }
        private void form_counterMain_Resize(object sender, EventArgs e)
        {
            changeFunc();
        }
        private void changeFunc()
        {
            int width, height;
            Point templocation = new Point(0, 0);
            width = this.Size.Width;
            height = this.Size.Height;
            width = width/3 -5; //here i calculated the best values for 3 buttons
            height = height/3-12;
            for (int i = 0; i < 9; i++) //here i assign some necessary values to buttons and read the count numbers from memory
            {
                btn[i].Name = "btn_" + i; //the names are changed!
                btn[i].TabIndex = i;
                btn[i].Text = b[i].ToString();
                btn[i].Size = new Size(width, height);
                btn[i].Visible = true;
                btn[i].Parent = this;
                btn[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            }
            //this lines sets the location of the buttons
            btn[0].Location = templocation;
            templocation.X = width;
            btn[1].Location = templocation;
            templocation.X = width * 2;
            btn[2].Location = templocation;
            templocation.X = 0;
            templocation.Y = height;
            btn[3].Location = templocation;
            templocation.X = width;
            btn[4].Location = templocation;
            templocation.X = width * 2;
            btn[5].Location = templocation;
            templocation.Y = height * 2;
            templocation.X = 0;
            btn[6].Location = templocation;
            templocation.X = width;
            btn[7].Location = templocation;
            templocation.X = width * 2;
            btn[8].Location = templocation;
        
        }
        //here the functions start, they only increase the integers in the memory and then they force the program to refresh its visual state
        private void btn0Click(Object sender, EventArgs e)
        {
            b[0]++;
            changeFunc();
        }
        private void btn1Click(Object sender, EventArgs e)
        {
            b[1]++;
            changeFunc();
        }
        private void btn2Click(Object sender, EventArgs e)
        {
            b[2]++;
            changeFunc();
        }
        private void btn3Click(Object sender, EventArgs e)
        {
            b[3]++;
            changeFunc();
        }
        private void btn4Click(Object sender, EventArgs e)
        {
            b[4]++;
            changeFunc();
        }
        private void btn5Click(Object sender, EventArgs e)
        {
            b[5]++;
            changeFunc();
        }
        private void btn6Click(Object sender, EventArgs e)
        {
            b[6]++;
            changeFunc();
        }
        private void btn7Click(Object sender, EventArgs e)
        {
            b[7]++;
            changeFunc();
        }
        private void btn8Click(Object sender, EventArgs e)
        {
            b[8]++;
            changeFunc();
        }
    }
