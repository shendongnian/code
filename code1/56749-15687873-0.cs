    using System.Windows.Controls;
    using System.Windows.Forms;
    using System.Windows.Input;
	public class LockableComboBox : ComboBox
	{
		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			if (this.IsReadOnly)
			{
				e.Handled = true;
			}
			else
			{
				base.OnSelectionChanged(e);
			}
		}
		protected override void OnPreviewKeyDown(KeyEventArgs e)
		{
			if (this.IsReadOnly)
			{
				if ((e.Key == Key.C || e.Key == Key.Insert)
					&& (Keyboard.Modifiers & ModifierKeys.Control) 
					== ModifierKeys.Control)
				{
					// Allow copy
					Clipboard.SetDataObject(SelectedValue, true);
				}
				e.Handled = true;
			}
			else
			{
				base.OnPreviewKeyDown(e);
			}
		}
		protected override void OnPreviewTextInput(TextCompositionEventArgs e)
		{
			if (this.IsReadOnly) 
			{
				e.Handled = true;
			}
			else
			{
				base.OnPreviewTextInput(e);
			}
		}
		protected override void OnKeyUp(KeyEventArgs e)
		{
			if (this.IsReadOnly)
			{
				e.Handled = true;
			}
			else
			{
				base.OnKeyUp(e);
			}
		}
	}
