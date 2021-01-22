		private void listBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != System.Windows.Forms.MouseButtons.Right)
				return;
			int index = listBox1.IndexFromPoint(e.X, e.Y);
			MessageBox.Show(listBox1.Items[index].ToString());
		}
