		IEnumerator<FrameworkElement> test2()
		{
			System.Windows.Controls.CheckBox checkbox1 = new System.Windows.Controls.CheckBox();
			System.Windows.Controls.CheckBox checkbox2 = new System.Windows.Controls.CheckBox();
			System.Windows.Controls.CheckBox checkbox3 = new System.Windows.Controls.CheckBox();
			List<System.Windows.Controls.CheckBox> list = new List<System.Windows.Controls.CheckBox> { checkbox1, checkbox2, checkbox3 };
			foreach (FrameworkElement entry in list)
			{
				yield return entry;
			}
		}
