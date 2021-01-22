        public Form1()
        {
            InitializeComponent();
            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            listBox1.DrawItem += new DrawItemEventHandler(listBox1_DrawItem);
            listBox1.MeasureItem += new MeasureItemEventHandler(listBox1_MeasureItem);      
        }
        void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(textBox1.Text, listBox1.Font).Height;
        }
        void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(textBox1.Text, listBox1.Font, Brushes.Black, e.Bounds);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1);
        }
