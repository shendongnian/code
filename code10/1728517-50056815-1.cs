      public string MyDataRow
            {
                get { return (string)GetValue(MyDataRowProperty); }
                set { SetValue(MyDataRowProperty, value); }
            }
        public static readonly DependencyProperty MyDataRowProperty = DependencyProperty.Register("MyDataRow", typeof(string), typeof(MyControl));        
       
