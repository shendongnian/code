     public Picker()
     {
         this.DefaultStyleKey = typeof(Picker);
         MyColors = new ObservableCollection<SolidColorBrush>()
      {
         new SolidColorBrush(Color.FromArgb(255,225,225,25)),
         new SolidColorBrush(Color.FromArgb(255,225,25,25)),
         new SolidColorBrush(Color.FromArgb(255,225,225,225)),
         new SolidColorBrush(Color.FromArgb(255,25,225,25))
      };
    
     }
    
     public ObservableCollection<SolidColorBrush> MyColors
     {
         get
         {
             return (ObservableCollection<SolidColorBrush>)GetValue(MyColorsProperty);
         }
         set { SetValue(MyColorsProperty, value); }
     }
    
     public static readonly DependencyProperty MyColorsProperty =
         DependencyProperty.Register("MyColors",
      typeof(ObservableCollection<SolidColorBrush>), typeof(Picker), new
          PropertyMetadata(null));
