		public static void PasteIntoCurrentTab(this TabControl tabControl)
		{
			if (tabControl.SelectedTab == null)
			{
				// Could throw here.
				return;
			}
			
			if (tabControl.SelectedTab.Controls.Count == 0)
			{
				// Could throw here.
				return;
			}
			
			RichTextBox textBox = tabControl.SelectedTab.Controls[0] as RichTextBox;
			if (textBox == null)
			{
				// Could throw here.
				return;
			}
			
			textBox.Paste();					
		}
