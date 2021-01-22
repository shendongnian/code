	public class Form1 : Form
	{
		static void Main(string[] args) { Application.Run(new Form1()); }
		public Form1()
		{
			this.IsMdiContainer = true;
			Panel test = new Panel();
			test.Dock = DockStyle.Top;
			test.Height = 100;
			this.Controls.Add(test);
			
			Form child = new Form();
			child.MdiParent = this;
			child.Text = "Child";
			child.Show();
		}
	}
