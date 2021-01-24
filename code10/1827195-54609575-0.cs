    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfCustomControlLibrary1
    {
      public class InputValuePage : Control
      {
        public static readonly DependencyProperty InputTitleProperty =
          DependencyProperty.Register ("InputTitle", typeof (string), typeof (InputValuePage));
    
        public string InputTitle
        {
          get { return (string)GetValue (InputTitleProperty); }
          set { SetValue (InputTitleProperty, value); }
        }
    
        static InputValuePage ( )
        {
          DefaultStyleKeyProperty.OverrideMetadata (typeof (InputValuePage), new FrameworkPropertyMetadata (typeof (InputValuePage)));
        }
      }
    }
