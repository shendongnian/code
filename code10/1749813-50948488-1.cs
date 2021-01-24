     WRONGWRONGWRONG:
      public static readonly DependencyProperty TBBackgroundProperty =
          DependencyProperty.Register("TBBackground", typeof(string), typeof(InputParameter),
              new PropertyMetadata("Black"));
        public string TBBackground
        {
            get
            {
                return (string)GetValue(TBBackgroundProperty);
            }
            set
            {
                SetValue(TBBackgroundProperty, value);
            }
        }
