    public class RichTextBoxHelper
    {
        public static readonly DependencyProperty BindableSelectionTextProperty =
           DependencyProperty.RegisterAttached("BindableSelectionText", typeof(string), 
           typeof(RichTextBoxHelper), new PropertyMetadata(null, BindableSelectionTextPropertyChanged));
        public static string GetBindableSelectionText(DependencyObject obj)
        {
            return (string)obj.GetValue(BindableSelectionTextProperty);
        }
        public static void SetBindableSelectionText(DependencyObject obj, string value)
        {
            obj.SetValue(BindableSelectionTextProperty, value);
        }
        public static void BindableSelectionTextPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            RichTextBox rtb = o as RichTextBox;
            if (rtb != null)
            {
                string text = e.NewValue as string;
                if (text != null)
                    rtb.Selection.Text = text;
            }
        }
    }    
