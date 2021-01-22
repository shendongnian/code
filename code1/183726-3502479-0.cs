    public partial class MyUserControl : UserControl, ICommandSource
    {
        public MyUserControl()
        {
            InitializeComponent();
        }
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(MyUserControl), new UIPropertyMetadata(null));
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(MyUserControl), new UIPropertyMetadata(null));
        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CommandTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(MyUserControl), new UIPropertyMetadata(null));
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            var command = Command;
            var parameter = CommandParameter;
            var target = CommandTarget;
            var routedCmd = command as RoutedCommand;
            if (routedCmd != null && routedCmd.CanExecute(parameter, target))
            {
                routedCmd.Execute(parameter, target);
            }
            else if (command != null && command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }
        }
    }
