    public class FocusableAutoCompleteBox : AutoCompleteBox
    {
        public new void Focus()
        {
            var textbox = Template.FindName("Text", this) as TextBox;
            if (textbox != null) textbox.Focus();
        }
    }
