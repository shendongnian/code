    public partial class Form1 : Form
    {
        private Button button1;
        private Button button2;
        public Form1()
        {
            InitializeComponent();
        }
        private void CreateButtons()
        {
            button1 = new Button()
            {
                Font = new Font(Font.FontFamily, 10, FontStyle.Bold),
                BackColor = Color.Yellow,
                Width = 79,
                Height = 62,
                Location = new Point(141, 191),
                Text = "Start"
            };
            button2 = new Button()
            {
                Font = new Font(Font.FontFamily, 10, FontStyle.Bold),
                BackColor = Color.Yellow,
                Width = 79,
                Height = 62,
                Location = new Point(338, 191),
                Text = "Stop"
            };
            this.Controls.Add(button1);
            button1.Click += Button1_Click;
            this.Controls.Add(button2);
            button2.Click += Button2_Click;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            button1.Click -= Button1_Click;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateButtons();
        }
    }
