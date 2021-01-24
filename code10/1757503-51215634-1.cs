			IEnumerator<FrameworkElement> testEnumerator2 = test2();
			while (testEnumerator2.MoveNext())
			{
				System.Windows.Controls.CheckBox checkbox = (System.Windows.Controls.CheckBox)testEnumerator2.Current;
				Console.WriteLine(checkbox.IsChecked);
			}
