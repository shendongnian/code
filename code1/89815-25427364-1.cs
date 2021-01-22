	namespace MyCustomComboBoxApp { using System.Windows.Controls;
	public class MyCustomComboBox : ComboBox
	{
		private int caretPosition;
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			var element = GetTemplateChild("PART_EditableTextBox");
			if (element != null)
			{
				var textBox = (TextBox)element;
				textBox.SelectionChanged += OnDropSelectionChanged;
			}
		}
		private void OnDropSelectionChanged(object sender, System.Windows.RoutedEventArgs e)
		{
			TextBox txt = (TextBox)sender;
			if (base.IsDropDownOpen && txt.SelectionLength > 0)
			{
				caretPosition = txt.SelectionLength; // caretPosition must be set to TextBox's SelectionLength
				txt.CaretIndex = caretPosition;
			}
			if (txt.SelectionLength == 0 && txt.CaretIndex != 0)
			{
				caretPosition = txt.CaretIndex;
			}
		}
	}
