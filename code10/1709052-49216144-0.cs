    public class EditBox : Control
    {
                static EditBox()
                {              
                public static readonly DependencyProperty ValueProperty =
                        DependencyProperty.Register(
                                "Value",
                                typeof(object),
                                typeof(EditBox),
                                new FrameworkPropertyMetadata());
    }
