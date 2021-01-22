    #region Attached Properties Boilerplate
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.RegisterAttached("IsActive", typeof(bool), typeof(ScrollIntoViewBehavior), new PropertyMetadata(false, OnIsActiveChanged));
        public static bool GetIsActive(FrameworkElement control)
        {
            return (bool)control.GetValue(IsActiveProperty);
        }
        public static void SetIsActive(
          FrameworkElement control, bool value)
        {
            control.SetValue(IsActiveProperty, value);
        }
        private static void OnIsActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behaviors = Interaction.GetBehaviors(d);
            var newValue = (bool)e.NewValue;
            
            if (newValue)
            {
                //add the behavior if we don't already have one
                if (!behaviors.OfType<ScrollIntoViewBehavior>().Any())
                {
                    behaviors.Add(new ScrollIntoViewBehavior());
                }
            }
            else
            {
                //remove any instance of the behavior. (There should only be one, but just in case.)
                foreach (var item in behaviors.ToArray())
                {
                    if (item is ScrollIntoViewBehavior)
                        behaviors.Remove(item);
                }
            }
        }
        #endregion
    <Style TargetType="Button">
        <Setter Property="Blah:ScrollIntoViewBehavior.IsActive" Value="True" />
    </Style>
