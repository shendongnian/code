    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(MyControls.AddLabel());
        }
    }
    public static class MyControls
    {
        public static Control AddLabel()
        {
            Label label = new Label
            {
                AutoSize = true,
                Location = new Point(48, 47),
                Name = "label1",
                Size = new Size(46, 17),
                TabIndex = 1,
                Text = "label1"
            };
            return label;
        }
    }
