    public partial class Form1 : Form
    {
        XDocument doc;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            doc = XDocument.Load("C:\\Users\\Mi\\Desktop\\Sxml.xml");
            var result = doc.Descendants("title").ToList();
            textBox1.Text = result[0].Value;
            listBox1.Items.Add(result[0].Value);
            listBox1.Items.Add(result[1].Value);
            listBox1.Items.Add(result[2].Value);
        }
    }
