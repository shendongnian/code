    public class BindingProxy : Freezable
    {
        #region Overrides of Freezable
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }
        #endregion
        public object MyData
        {
            get { return (object)GetValue(MyDataProperty); }
            set { SetValue(MyDataProperty, value); }
        }
        public static readonly DependencyProperty MyDataProperty =
            DependencyProperty.Register("MyData", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
    }
