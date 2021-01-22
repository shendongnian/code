        #region MyList dependency property
        public static readonly DependencyProperty MyListProperty = DependencyProperty.Register("MyList", typeof(ObservableCollection<String>), typeof(Window1));
        public ObservableCollection<String> MyList
        {
            get { return (ObservableCollection<String>) GetValue(MyListProperty); }
            set { SetValue(MyListProperty, value); }
        }
        #endregion
