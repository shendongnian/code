        private void OpenView<TViewType, TViewModelType>(object parameters)
            where viewType : FrameworkElement // This is the magic sauce
        {
            var view = (TViewType)Activator.CreateInstance(typeof(TViewType));            
    
            // Now we can access the DataContext
            var viewModel = (TViewModelType)view.DataContext;  
            //snip
        }
