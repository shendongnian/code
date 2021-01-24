    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10000; i++)
                Controls.Add(new Label { Text = $"{i}" });
        }
    }
