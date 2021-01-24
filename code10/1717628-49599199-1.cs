    public enum MouseWheelDirection { Up, Down }
    
    public class MouseWheelGesture : MouseGesture
    {
        public MouseWheelDirection Direction { get; set; }
    
        public MouseWheelGesture(ModifierKeys keys, MouseWheelDirection direction)
            : base(MouseAction.WheelClick, keys)
        {
            Direction = direction;
        }
    
        public override bool Matches(object targetElement, InputEventArgs inputEventArgs)
        {
            var args = inputEventArgs as MouseWheelEventArgs;
            if (args == null)
                return false;
            if (!base.Matches(targetElement, inputEventArgs))
                return false;
            if (   Direction == MouseWheelDirection.Up && args.Delta > 0
                || Direction == MouseWheelDirection.Down && args.Delta < 0)
            {
                inputEventArgs.Handled = true;
                return true;
            }
    
            return false;
        }
    
    }
    
    public class MouseWheel : MarkupExtension
    {
        public MouseWheelDirection Direction { get; set; }
        public ModifierKeys Keys { get; set; }
    
        public MouseWheel()
        {
            Keys = ModifierKeys.None;
            Direction = MouseWheelDirection.Down;
        }
    
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new MouseWheelGesture(Keys, Direction);
        }
    }
