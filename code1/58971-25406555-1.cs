        protected override Windows.UI.Xaml.DataTemplate SelectTemplateCore(object item, Windows.UI.Xaml.DependencyObject container)
        {
            var parent = FindParent<MyParentControlType>(container as FrameworkElement);
            if(parent != null)
            {
                if (item is Something)
                    return parent.Resources["TemplateForSomething"] as DataTemplate;
                else if(item is SomethingElse)
                    return parent.Resources["TemplateForSomethingElse"] as DataTemplate;
                else 
                    // etc
            }
            else
            {
                return App.Current.Resources["SomeFallbackResource"] as DataTemplate;
            }
        }
        public static T FindParent<T>(FrameworkElement element) where T : FrameworkElement
        {
            FrameworkElement parent = Windows.UI.Xaml.Media.VisualTreeHelper.GetParent(element) as FrameworkElement;
            while (parent != null)
            {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                    return correctlyTyped;
                else
                    return FindParent<T>(parent);
            }
            return null;
        }
