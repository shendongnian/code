	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
			listBox1.Items.Add("1");
			listBox1.Items.Add("2");
			listBox1.Items.Add("3");
		}
		void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			listBox2.Items.Add(listBox1.SelectedItem);
		}
	}
