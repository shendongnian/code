    App.Current.Dispatcher.Invoke((Action)delegate
            {
                CategoriesView = CollectionViewSource.GetDefaultView(_mainViewModel.Categories );
                CategoriesView .Filter = new Predicate<object>(o => Filter(o as Category));
            });
