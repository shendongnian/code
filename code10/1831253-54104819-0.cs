`
    public partial class Form1 : Form
    {
        int height, width;
        bool IsFirstClick = false;
        public Form1()
        {
            InitializeComponent();
            height = groupBox1.Height;
            width = groupBox1.Width;
            groupBox1.Height = 0;
            groupBox1.Width = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsFirstClick)
            {
                IsFirstClick = true;
                groupBox1.Width = width;
                for (int i = 0; i < height; i++)
                {
                    groupBox1.Height = i;
                }
            }
            else
            {
                IsFirstClick = false;
                for (int i = height; i>0; i--)
                {
                    groupBox1.Height = i;
                }
                groupBox1.Width = 0;
            }
        }
    }
`
