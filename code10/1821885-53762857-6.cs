    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interactivity;
    
    namespace TestWpfApplication
    {
        public class SwipeBehavior : Behavior<Window>
        {
            public static readonly DependencyProperty TargetContentControlProperty = DependencyProperty.RegisterAttached("TargetContentControl", typeof(ContentControl), typeof(SwipeBehavior), new UIPropertyMetadata(null));
    
            public static readonly DependencyProperty LeftUserControlProperty = DependencyProperty.RegisterAttached("LeftUserControl", typeof(UserControl), typeof(SwipeBehavior), new UIPropertyMetadata(null));
    
            public static readonly DependencyProperty RightUserControlProperty = DependencyProperty.RegisterAttached("RightUserControl", typeof(UserControl), typeof(SwipeBehavior), new UIPropertyMetadata(null));
    
            public static ContentControl GetTargetContentControl(DependencyObject dependencyObject)
            {
                return (ContentControl) dependencyObject.GetValue(TargetContentControlProperty);
            }
    
            public static void SetTargetContentControl(DependencyObject dependencyObject, ContentControl value)
            {
                dependencyObject.SetValue(TargetContentControlProperty, value);
            }
    
            public static ContentControl GetLeftUserControl(DependencyObject dependencyObject)
            {
                return (UserControl) dependencyObject.GetValue(LeftUserControlProperty);
            }
    
            public static void SetLeftUserControl(DependencyObject dependencyObject, UserControl value)
            {
                dependencyObject.SetValue(LeftUserControlProperty, value);
            }
    
            public static ContentControl GetRightUserControl(DependencyObject dependencyObject)
            {
                return (UserControl) dependencyObject.GetValue(RightUserControlProperty);
            }
    
            public static void SetRightUserControl(DependencyObject dependencyObject, UserControl value)
            {
                dependencyObject.SetValue(RightUserControlProperty, value);
            }
    
            private Point _swipeStart;
    
            protected override void OnAttached()
            {
                base.OnAttached();
                AssociatedObject.MouseDown += OnMouseDown;
                AssociatedObject.MouseMove += OnMouseMove;
            }
    
            private void OnMouseDown(object sender, MouseButtonEventArgs e)
            {
                _swipeStart = e.GetPosition(AssociatedObject);
            }
    
            private void OnMouseMove(object sender, MouseEventArgs e)
            {
                var targetContentControl = GetValue(TargetContentControlProperty) as ContentControl;
    
                if (targetContentControl == null)
                {
                    return;
                }
    
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    var swipe = e.GetPosition(AssociatedObject);                
    
                    //Swipe Left
                    if (swipe.X > (_swipeStart.X + 200))
                    {
                        // OR Use Your Logic to switch between pages.
                        targetContentControl.Content = new LeftControl();
                    }
    
                    //Swipe Right
                    if (swipe.X < (_swipeStart.X - 200))
                    {
                        // OR Use Your Logic to switch between pages.
                        targetContentControl.Content = new RightControl();
                    }
                }
    
                e.Handled = true;
            }
        }
    }
