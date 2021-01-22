    public class AutoCompleteFocusableBox : AutoCompleteBox
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var textbox = Template.FindName("Text", this) as TextBox;
            if(textbox != null) textbox.Focus();
        }
    }
