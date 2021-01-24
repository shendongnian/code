    public partial class comPortWindow : Form
	{
		public comPortWindow()
		{
			InitializeComponent();
		}
		public void comportLogText(string text)
		{
				updateRichTextBox1(text);
		}
		private void updateRichTextBox1(string text)
		{
			richTextBox2.Text = text + " : " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "\r\n" + richTextBox2.Text;
			richTextBox2.ScrollToCaret();
		}
	}
