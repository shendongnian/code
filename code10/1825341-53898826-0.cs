      public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register(
              nameof(SetState),
              typeof(bool),
              typeof(CustomControl),
          new PropertyMetadata(false, null,
             (d, v) =>
             {
                ((CollapsibleColumnDefinition)d).IsExpanded = (bool)v;
                return v;
             }));
