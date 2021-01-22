        public static readonly DependencyProperty HeaderPropertyProperty =
            DependencyProperty.Register("HeaderProperty", typeof(string), typeof(ownerclass), new PropertyMetadata(OnHeaderPropertyChanged));
        public string HeaderProperty        
        {
            get { return (string)GetValue(HeaderPropertyProperty); }
            set { SetValue(HeaderPropertyProperty, value); }
        }
       public static void OnHeaderPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (args.NewValue != null)
            {
                ownerclass c = (ownerclass) obj;
                
                Binding b = new Binding();
                b.Path = new PropertyPath(args.NewValue.ToString());
                c.SetBinding(ownerclass.HeaderProperty, b);
            }
        }
