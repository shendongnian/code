    using System;
    using System.Collections;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media.Animation;
    
    namespace WpfApplication5
    {
      public partial class Window1 : Window
      {
        public Window1()
        {
          InitializeComponent();
        }
      }
    
      public class StyleAnimation : DependencyObject
      {
        private const int DURATION_MS = 200;
    
        private static readonly Hashtable _hookedElements = new Hashtable();
    
        public static readonly DependencyProperty IsActiveProperty =
          DependencyProperty.RegisterAttached("IsActive",
          typeof(bool),
          typeof(StyleAnimation),
          new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnIsActivePropertyChanged)));
    
        public static bool GetIsActive(UIElement element)
        {
          if (element == null)
          {
            throw new ArgumentNullException("element");
          }
    
          return (bool)element.GetValue(IsActiveProperty);
        }
    
        public static void SetIsActive(UIElement element, bool value)
        {
          if (element == null)
          {
            throw new ArgumentNullException("element");
          }
          element.SetValue(IsActiveProperty, value);
        }
    
        static StyleAnimation()
        {
          // You can specify any owner type, derived from FrameworkElement.
          // For example if you want to animate style for every Control derived
          // class - use Control. If Label is your single target - set it to label.
          // But be aware: value coercion will be called every time your style is
          // updated. So if you have performance problems, probably you should
          // narrow owner type to your exact type.
          FrameworkElement.StyleProperty.AddOwner(typeof(Control),
                                                  new FrameworkPropertyMetadata(
                                                    null, new PropertyChangedCallback(StyleChanged), CoerceStyle));
        }
    
        private static object CoerceStyle(DependencyObject d, object baseValue)
        {
          var c = d as Control;
          if (c == null || c.Style == baseValue)
          {
            return baseValue;
          }
    
          if (CheckAndUpdateAnimationStartedFlag(c))
          {
            return baseValue;
          }
          // If we get here, it means we have to start our animation loop:
          // 1. Hide control with old style.
          // 2. When done set control's style to new one. This will reenter to this
          // function, but will return baseValue, since CheckAndUpdateAnimationStartedFlag()
          // will be true.
          // 3. Show control with new style.
    
          var showAnimation = new DoubleAnimation
          {
            Duration =
              new Duration(TimeSpan.FromMilliseconds(DURATION_MS)),
            To = 1
          };
    
    
          var hideAnimation = new DoubleAnimation
          {
            Duration = new Duration(TimeSpan.FromMilliseconds(DURATION_MS)),
            To = 0
          };
    
          hideAnimation.Completed += (o, e) =>
          {
            // To stress it one more: this will trigger value coercion again,
            // but CheckAndUpdateAnimationStartedFlag() function will reture true
            // this time, and we will not go to this loop again.
            c.CoerceValue(FrameworkElement.StyleProperty);
            c.BeginAnimation(UIElement.OpacityProperty, showAnimation);
          };
    
          c.BeginAnimation(UIElement.OpacityProperty, hideAnimation);
          return c.Style; // Return old style this time.
        }
    
        private static void StyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
          // So what? Do nothing.
        }
    
        private static void OnIsActivePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
          var fe = d as FrameworkElement;
          if (fe == null)
          {
            return;
          }
          if (GetIsActive(fe))
          {
            HookStyleChanges(fe);
          }
          else
          {
            UnHookStyleChanges(fe);
          }
        }
    
        private static void UnHookStyleChanges(FrameworkElement fe)
        {
          if (_hookedElements.Contains(fe))
          {
            _hookedElements.Remove(fe);
          }
        }
    
        private static void HookStyleChanges(FrameworkElement fe)
        {
          _hookedElements.Add(fe, false);
        }
    
        private static bool CheckAndUpdateAnimationStartedFlag(Control c)
        {
          var hookedElement = _hookedElements.Contains(c);
          if (!hookedElement)
          {
            return true; // don't need to animate unhooked elements.
          }
    
          var animationStarted = (bool)_hookedElements[c];
          _hookedElements[c] = !animationStarted;
    
          return animationStarted;
        }
      }
    
      public class BooleanStyleConverter : IValueConverter
      {
        public Style StyleFalse { get; set; }
        public Style StyleTrue { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          if ((bool)value)
          {
            return StyleTrue;
          }
          return StyleFalse;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
          throw new NotImplementedException();
        }
      }
    }
