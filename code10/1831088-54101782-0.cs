public string UniqueProperty
        {
            get { return (string)GetValue(UniquePropertyDP); }
            set { SetValue(UniquePropertyDP, value); }
        }
public static readonly DependencyProperty UniquePropertyDP=
    DependencyProperty.Register(
        "UniqueProperty",
        typeof(string),
        typeof(ReusableControl),
        new PropertyMetadata(string.Empty, null, UniquePropertyCoerceValueCallback));
private static object UniquePropertyCoerceValueCallback(DependencyObject d, object value)
{
    ((ReusableControl)d).UniquePropertyTextBox.GetBindingExpression(TextBox.TextProperty)
        .UpdateTarget();
    return value;
}
When the value of one of the unique properties changes and the ViewModel fires the PropertyChange event for the other unique property in the ViewModel, the DependencyProperty in the UserControl will be re-coerced, triggering this callback and updating validation. 
