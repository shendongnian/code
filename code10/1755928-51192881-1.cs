	namespace WindowsFormsApp1
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
			private void new_button_Click(object sender, EventArgs e)
			{
				if (!container.Controls.Contains(@new.Instance))
				{
					container.Controls.Add(@new.Instance);
					@new.Instance.Dock = DockStyle.Fill;
					@new.Instance.BringToFront();
				}
				else
				{
					@new.Instance.BringToFront();
				}
			}
			private void new_StepCompleted(object sender, EventArgs e)
			{
				if (!container.Controls.Contains(choice.Instance))
				{
					container.Controls.Add(choice.Instance);
					choice.Instance.Dock = DockStyle.Fill;
					choice.Instance.BringToFront();
				}
				else
				{
					choice.Instance.BringToFront();
				}
			}
		}
	}
