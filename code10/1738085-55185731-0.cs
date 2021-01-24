    public class HoverOverImage : Image
    {
        public static DependencyProperty MouseOverFrameAreaProperty = DependencyProperty.Register("MouseOverFrameArea", typeof(bool), typeof(HoverOverImage)
            , new FrameworkPropertyMetadata(false, OnMouseOverFrameAreaChanged));
        private bool _mouseOverFrameArea = false;
        public bool MouseOverFrameArea
        {
            get => _mouseOverFrameArea;
            set
            {
                _mouseOverFrameArea = value;
                if (DataContext != null && DataContext.GetType()==typeof(MyViewModel))
                    ((MyViewModel)DataContext).MouseOverFrameArea = value;
            }
        }
        private static void OnMouseOverFrameAreaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((HoverOverImage)d).MouseOverFrameArea = (bool)e.NewValue;
        }
    }
