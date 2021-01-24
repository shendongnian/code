    public class MouseHorizontalWheelEventArgs : MouseEventArgs
    {
        public int HorizontalDelta { get; }
        public MouseHorizontalWheelEventArgs(MouseDevice mouse, int timestamp, int horizontalDelta)
            : base(mouse, timestamp)
        {
            HorizontalDelta = horizontalDelta;
        }
        protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
        {
            MouseHorizontalWheelEventHandler handler = (MouseHorizontalWheelEventHandler)genericHandler;
            handler(genericTarget, this);
        }
    }
