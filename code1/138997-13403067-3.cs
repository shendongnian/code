    /// <summary>
    /// behavior that makes a window/dialog draggable by clicking anywhere 
    /// on it that is not a control (ie, button)
    /// </summary>
    public class DragMoveBehavior<T> : Behavior<T> where T : FrameworkElement
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += MouseDown;
            base.OnAttached();
        }
        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= MouseDown;
            base.OnDetaching();
        }
        void MouseDown( object sender, EventArgs ea ) => Window.GetWindow( sender as T )?.DragMove();
    }
    public class WinDragMoveBehavior : DragMoveBehavior<Window> { }
    public class UCDragMoveBehavior : DragMoveBehavior<UserControl> { }
    /// <summary>
    /// behavior that makes a window/dialog not resizable while clicked.  this prevents
    /// the window from being snapped to the edge of the screen (AeroSnap).  if DragMoveBehavior
    /// is also used, this must be attached first.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NoSnapBehavior<T> : Behavior<T> where T : FrameworkElement
    {
        ResizeMode lastMode = ResizeMode.NoResize;
        protected override void OnAttached()
        {
            AssociatedObject.MouseLeftButtonDown += MouseDown;
            AssociatedObject.MouseLeftButtonUp += MouseUp;
            base.OnAttached();
        }
        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= MouseDown;
            AssociatedObject.MouseLeftButtonUp -= MouseUp;
            base.OnDetaching();
        }
        /// <summary>
        /// make it so the window can be moved by dragging
        /// </summary>
        void MouseDown( object sender, EventArgs ea )
        {
            var win = Window.GetWindow( sender as T );
            if( win != null && win.ResizeMode != ResizeMode.NoResize )
            {
                lastMode = win.ResizeMode;
                win.ResizeMode = ResizeMode.NoResize;
                win.UpdateLayout();
            }
        }
        void MouseUp( object sender, EventArgs ea )
        {
            var win = Window.GetWindow( sender as T );
            if( win != null && win.ResizeMode != lastMode )
            {
                win.ResizeMode = lastMode;
                win.UpdateLayout();
            }
        }
    }
    public class WinNoSnapBehavior : NoSnapBehavior<Window> { }
    public class UCNoSnapBehavior : NoSnapBehavior<UserControl> { }
