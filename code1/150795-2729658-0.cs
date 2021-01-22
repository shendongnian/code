    public Binding GetResourceBinding(string key)
            {
                var b = new Binding(key);
                b.Source = ((ResourceWrapper)App.Current.Resources["ResourceWrapper"]).ApplicationStrings;
                b.Mode = BindingMode.OneWay;
    
                return b;
            }
