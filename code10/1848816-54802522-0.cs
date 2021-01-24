        public int _valueBtn1;
        public int _valueBtn2;
        public int _valueSelectedBtn;
        public bool wasClicked1 = false;
        public bool wasClicked2 =  false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        // BUTTON [?] - TOP
        private void button3_Click(object sender, EventArgs e)
        {
            wasClicked1 = true;
        }
        // BUTTON [5]
        private void button4_Click(object sender, EventArgs e)
        {
            if (wasClicked1)
            {
                _valueSelectedBtn = Convert.ToInt32(this.button4.Text);
                button3.Text = _valueSelectedBtn.ToString();
                wasClicked1 = false;
            }
            else if (wasClicked2)
            {
                _valueSelectedBtn = Convert.ToInt32(this.button4.Text);
                button5.Text = _valueSelectedBtn.ToString();
                wasClicked2 = false;
            }
        }
        // BUTTON [?] - bottom 
        private void button5_Click(object sender, EventArgs e)
        {
            wasClicked2 = true;
        }
        // BUTTON [2]
        private void button8_Click(object sender, EventArgs e)
        {
            if (wasClicked1)
            {
                _valueSelectedBtn = Convert.ToInt32(this.button8.Text);
                button3.Text = _valueSelectedBtn.ToString();
                wasClicked1 = false;
            }
            else if (wasClicked2)
            {
                _valueSelectedBtn = Convert.ToInt32(this.button8.Text);
                button5.Text = _valueSelectedBtn.ToString();
                wasClicked2 = false;
            }
        }
    }
