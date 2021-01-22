      public Boolean PasswordBoxVisible {
         get { return (Boolean)GetValue(PasswordBoxVisibleProperty); }
         set { SetValue(PasswordBoxVisibleProperty, value); }
      }
      public static readonly DependencyProperty PasswordBoxVisibleProperty =
          DependencyProperty.Register("PasswordBoxVisible", typeof(Boolean), typeof(UserControl), new UIPropertyMetadata(false, new PropertyChangedCallback(PropChanged)));
      //this method is called when the dp is changed
      static void PropChanged(DependencyObject o, DependencyPropertyChangedEventArgs e) {
           UserControl userControl = o as UserControl;
           //now you can use this to call some methods, raise other value changed etc, in this case OtherProperty.
           userControl.NotifyPropertyChanged("OtherProperty");
      }
