            get { 
                return (ObservableCollection<DataGridColumn>)GetValue(ColumnsProperty); }
            set
            {
                SetValue(ColumnsProperty, value);
            }
        
        }
        public static readonly DependencyProperty ColumnsProperty =
        DependencyProperty.Register("gridColumns", typeof(ObservableCollection<DataGridColumn>),
            typeof(parentControl), new PropertyMetadata(new ObservableCollection<DataGridColumn>()));
