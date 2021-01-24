    public class CommandProviders
    {
        public static ICommand GetCommand(DependencyObject depObject)
        {
            return (ICommand)depObject.GetValue(CommandProprtey);
        }
        public static void SetCommand(DependencyObject depobject, ICommand value)
        {
            depobject.SetValue(CommandProprtey, value);
        }
        public static readonly DependencyProperty CommandProprtey =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(CommandProviders), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnCommandChanged)));
    }
    private static void OnCommandChanged
    (DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ComboBox cmbBox= (ComboBox)d;
        if (cmbBox != null)     
        {
            cmbBox.SelectionChanged += (sender, eventArgs) => 
               {
                   d.GetValue(CommandProprtey)?.Invoke(null);
               }
        }
    }
