    public class DebugAction : TriggerAction<DependencyObject>
    {
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(DebugAction), new UIPropertyMetadata(""));
        public object MessageParameter
        {
            get { return (object)GetValue(MessageParameterProperty); }
            set { SetValue(MessageParameterProperty, value); }
        }
        public static readonly DependencyProperty MessageParameterProperty =
            DependencyProperty.Register("MessageParameter", typeof(object), typeof(DebugAction), new UIPropertyMetadata(null));
        protected override void Invoke(object parameter)
        {
            Debug.WriteLine(Message, MessageParameter, AssociatedObject, parameter);
        }
    }
