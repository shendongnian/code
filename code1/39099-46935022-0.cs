    public class ElementBehavior
    {
        #region AlwaysOverride
        ///<summary>
        /// DependencyProperty
        ///</summary>
        public static readonly DependencyProperty AlwaysOverrideProperty = DependencyProperty.RegisterAttached("AlwaysOverride", typeof(bool), typeof(ElementBehavior), new PropertyMetadata(false, OnAlwaysOverrideChanged));
        ///<summary>
        /// Get
        ///</summary>
        ///<param name="target">DependencyObject</param>
        ///<returns>ICommand</returns>
        public static bool GetAlwaysOverride(DependencyObject target)
        {
            return (bool)target.GetValue(AlwaysOverrideProperty);
        }
        ///<summary>
        /// Set
        ///</summary>
        ///<param name="target">DependencyObject</param>
        ///<param name="value">ICommand</param>
        public static void SetAlwaysOverride(DependencyObject target, bool value)
        {
            target.SetValue(AlwaysOverrideProperty, value);
        }
        ///<summary>1
        /// OnChanged
        ///</summary>
        ///<param name="target">DependencyObject</param>
        ///<param name="e">DependencyPropertyChangedEventArgs</param>
        public static void OnAlwaysOverrideChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (target.GetType() == typeof(TextBox))
            {
                TextBox t = (TextBox)target;
                if ((bool)e.NewValue)
                {
                    t.PreviewKeyDown += OnAlwaysOverride;
                }
                else
                {
                    t.PreviewKeyDown -= OnAlwaysOverride;
                }
            }
        }
        private static void OnAlwaysOverride(object sender, KeyEventArgs e)
        {
            TextBox t = (TextBox)e.Source;
            Key[] BAD_KEYS = new Key[] { Key.Back, Key.Delete };
            Key[] WRK_KEYS = new Key[] { Key.Left, Key.Up, Key.Right, Key.Down, Key.Enter };
            if (BAD_KEYS.Contains(e.Key))
            {
                e.Handled = true;
            }
            else if (WRK_KEYS.Contains(e.Key) == false && string.IsNullOrEmpty(t.Text) == false)
            {
                t.Select(t.CaretIndex, 1);
            }
        }
        #endregion
    }
