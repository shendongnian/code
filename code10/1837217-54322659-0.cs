    public class ExtendedCheckedListBox : ListBox
    {
        static ExtendedCheckedListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ExtendedCheckedListBox),
                new FrameworkPropertyMetadata(typeof(ExtendedCheckedListBox)));
        }
    }
