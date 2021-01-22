        protected override void OnPropertyChanged( DependencyPropertyChangedEventArgs e ) {
            base.OnPropertyChanged( e );
            if( e.Property == DataSourceProperty ) {
                underlyingGrid.DataSource = e.NewValue;
            }
        }
