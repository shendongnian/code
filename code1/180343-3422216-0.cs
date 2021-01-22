	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			UpdateCustDetails();
		}
		public void updateLabel(Label lb, string text)
		{
			lb.Text = text;
		}
		public void UpdateCustDetails()
		{
			updateLabel(label1, "Test");
			updateLabel(label2, "Test1234");
			updateLabel(label3, "Test5678");
			updateLabel(label4, "Test0000");
		}
	}
