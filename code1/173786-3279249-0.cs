      public class TreeViewItemService
      {
        public static readonly DependencyProperty SelectWhenKeyboardIsFocusedProperty = DependencyProperty.RegisterAttached("SelectWhenKeyboardIsFocused",
          typeof(bool), typeof(TreeViewItemService), new FrameworkPropertyMetadata(false, TreeViewItemService.OnSelectWhenKeyboardIsFocusedPropertyChanged));
    
        static void OnSelectWhenKeyboardIsFocusedPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
          FrameworkElement element = sender as FrameworkElement;
          if (element == null)
            return;
    
          TreeViewItem target = MTVisualTreeHelper.FindParent<TreeViewItem>(element as DependencyObject);
          if (target != null)
            new IsSelectedOnKeyboardFocusAction(element, target);
        }
    
        public static bool GetSelectWhenKeyboardIsFocused(FrameworkElement target)
        {
          return (bool)target.GetValue(SelectWhenKeyboardIsFocusedProperty);
        }
    
        public static void SetSelectWhenKeyboardIsFocused(FrameworkElement target, bool value)
        {
          target.SetValue(SelectWhenKeyboardIsFocusedProperty, value);
        }
    
        private class IsSelectedOnKeyboardFocusAction
        {
          TreeViewItem m_Target;
          FrameworkElement m_Source;
    
          public IsSelectedOnKeyboardFocusAction(FrameworkElement source, TreeViewItem item)
          {
            m_Source = source;
            m_Target = item;
            m_Source.Loaded += OnSource_Loaded;
            m_Source.Unloaded += OnSource_Unloaded;
          }
    
          void OnSource_Loaded(object sender, RoutedEventArgs e)
          {
            m_Source.PreviewMouseLeftButtonDown += OnSource_PreviewMouseLeftButtonDown;
            m_Source.GotFocus += OnSource_GotFocus;
            m_Source.LostFocus += OnSource_LostFocus;
            m_Source.GotKeyboardFocus += OnSource_GotKeyboardFocus;
            m_Source.LostKeyboardFocus += OnSource_LostKeyboardFocus;
          }
    
          void OnSource_Unloaded(object sender, RoutedEventArgs e)
          {
            m_Source.PreviewMouseLeftButtonDown -= OnSource_PreviewMouseLeftButtonDown;
            m_Source.GotFocus -= OnSource_GotFocus;
            m_Source.LostFocus -= OnSource_LostFocus;
            m_Source.GotKeyboardFocus -= OnSource_GotKeyboardFocus;
            m_Source.LostKeyboardFocus -= OnSource_LostKeyboardFocus;
          }
    
          void OnSource_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
          {
            if (!m_Target.IsSelected)
              m_Target.IsSelected = true;
          }
    
          void OnSource_GotFocus(object sender, RoutedEventArgs e)
          {
            if (!m_Target.IsSelected)
              m_Target.IsSelected = true;
          }
    
          void OnSource_LostFocus(object sender, RoutedEventArgs e)
          {
            if (m_Target.IsSelected)
              m_Target.IsSelected = false;
          }
    
          void OnSource_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
          {
            if (!m_Target.IsSelected)
              m_Target.IsSelected = true;
          }
    
          void OnSource_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
          {
            if (m_Target.IsSelected)
              m_Target.IsSelected = false;
          }
    
        }
    
      }
