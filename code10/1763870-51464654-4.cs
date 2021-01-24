    public class MyClass : DependencyObject
    {
    /// <summary>
    /// Gets or Sets SelectedAmount Dependency Property
    /// </summary>
    public int SelectedAmount 
    {
        get { return (int)GetValue(SelectedAmountProperty); }
        set { SetValue(SelectedAmount Property, value); }
    }
    public static readonly DependencyProperty SelectedAmountProperty =
        DependencyProperty.Register("SelectedAmount ", typeof(int), typeof(MyClass), new PropertyMetadata(0));
    }
