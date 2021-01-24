    public static readonly DependencyProperty TBBackgroundProperty =
          DependencyProperty.Register("TBBackground", typeof(SolidColorBrush), typeof(InputParameter),
              new PropertyMetadata(new SolidColorBrush(Colors.White)));
        public Brush TBBackground
        {
            get
            {
                return (Brush)GetValue(TBBackgroundProperty);
            }
            set
            {
                SetValue(TBBackgroundProperty, value);
            }
        }
