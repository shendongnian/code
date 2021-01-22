    public class MyComboBox : System.Windows.Controls.Combobox
    {
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            //Get the new focused element and in case this is not an existing item of the current combobox then perform a lost focus command.
            //Otherwise the drop down items have been opened and is still focused on the current combobox
            var focusedElement = FocusManager.GetFocusedElement(FocusManager.GetFocusScope(this));
            if (!(focusedElement is ComboBoxItem && ItemsControl.ItemsControlFromItemContainer(focusedElement as ComboBoxItem) == this))
            {
                base.OnLostFocus(e);
                /* Your code here... */
            }
        }
    }
