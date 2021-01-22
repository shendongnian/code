        void Filter(Func<Foo, bool> filterFunc)
        {
            foreach (var item in foos)
            {
                if (!filterFunc(item))
                    item.Visibility = Visibility.Collapsed;
                else
                    item.Visibility = Visibility.Visible;
            }
        }
