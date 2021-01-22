    class MyClass : FrameworkElement {
    
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e) {
            base.OnPropertyChanged(e);
            if (e.Property == FrameworkElement.DataContextProperty) {
                // do something with e.NewValue/e.OldValue
            }
        }
    }
