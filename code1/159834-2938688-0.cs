    Binding binding = new Binding {
      Source = TitleLabel,
      Path = new PropertyPath("Content"),
    };
    BottomLabel.SetBinding(ContentControl.ContentProperty, binding);
