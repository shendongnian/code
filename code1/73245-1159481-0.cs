		private void Form1_Load(object sender, EventArgs e)
		{
			foreach (Control control in Controls)
			{
				control.Enter += ControlReceivedFocus;
			}
		}
		void ControlReceivedFocus(object sender, EventArgs e)
		{
			Debug.WriteLine(sender + " received focus.");
		}
