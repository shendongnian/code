     public object MySelectedItem
        {
            get { return (object)GetValue(Property1Property); }
            set { SetValue(Property1Property, value); }
        }
                public static readonly DependencyProperty Property1Property
            = DependencyProperty.Register(
                  "MySelectedItem",
                  typeof(object),
                  typeof(PromotionsMenu),
                  new PropertyMetadata(false)
              );
