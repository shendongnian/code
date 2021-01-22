    public class AllowableCharactersTextBoxBehavior : Behavior<TextBox>
    {
        public static readonly DependencyProperty RegularExpressionProperty =
            DependencyProperty.Register("RegularExpression", typeof(string), typeof(AllowableCharactersTextBoxBehavior),
            new FrameworkPropertyMetadata("*"));
    public string RegularExpression
    {
        get
        {
            return (string)base.GetValue(RegularExpressionProperty);
        }
        set
        {
            base.SetValue(RegularExpressionProperty, value);
        }
    }
    public static readonly DependencyProperty MaxLengthProperty =
    DependencyProperty.Register("MaxLength", typeof(int), typeof(AllowableCharactersTextBoxBehavior),
    new FrameworkPropertyMetadata(int.MinValue));
    public int MaxLength
    {
        get
        {
            return (int)base.GetValue(MaxLengthProperty);
        }
        set
        {
            base.SetValue(MaxLengthProperty, value);
        }
    }
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.PreviewTextInput += OnPreviewTextInput;
        DataObject.AddPastingHandler(AssociatedObject, OnPaste);
    }
    private void OnPaste(object sender, DataObjectPastingEventArgs e)
    {
        if (e.DataObject.GetDataPresent(DataFormats.Text))
        {
            string text = Convert.ToString(e.DataObject.GetData(DataFormats.Text));
            bool exceedsMaxLength = false;
            if (MaxLength > 0)
            {
                exceedsMaxLength = text.Length > MaxLength;
            }
            if (!ViewModel.ValidationHelper.IsMatch(text, RegularExpression) || exceedsMaxLength)
            {
                e.CancelCommand();
            }
        }
        else
        {
            e.CancelCommand();
        }
    }
    void OnPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        bool exceedsMaxLength = false;
        if (MaxLength > 0)
        {
            exceedsMaxLength = AssociatedObject.Text.Length > MaxLength;
        }
        e.Handled = !ViewModel.ValidationHelper.IsMatch(AssociatedObject.Text, RegularExpression) || exceedsMaxLength;
    }
    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.PreviewTextInput -= OnPreviewTextInput;
        DataObject.RemovePastingHandler(AssociatedObject, OnPaste);
    }
    }
 
