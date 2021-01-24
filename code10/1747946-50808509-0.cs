    public class iOSScrollingEffect : PlatformEffect
    {
    
        UIScrollView nativeControl;
        private bool _isAttached;
        protected override void OnAttached()
        {
            nativeControl = Control as UIScrollView;
            if (nativeControl != null && !_isAttached)
            {
                nativeControl.Scrolled += NativeControl_Scrolled;
                _isAttached = true;
            }
        }
    
        private void NativeControl_Scrolled(object sender, EventArgs e)
        {
            ...
        }
        protected override void OnDetached()
        {
            if (_isAttached)
            {
                nativeControl.Scrolled -= NativeControl_Scrolled;
                _isAttached = false;
            }
        }
    }
