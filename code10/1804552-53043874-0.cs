        NavigateCommand = new RelayCommandAsync<object>(NavigateAsync, CanNavigate);  
        ...
        private async Task NavigateAsync(object parameter)
        {
            if (IsBusy)
                return Task.CompletedTask;
            IsBusy = true;
            NavigateCommand.OnCanExecuteChanged();
    
            var page = (string) parameter;
    
            switch (page)
            {
                case "Page1":
                    await App.MainNavigation.PushAsync(new Views.Page1(), true);
    
                //More cases here
            }
            IsBusy = false;
            NavigateCommand.OnCanExecuteChanged();
        }
        
        private bool CanNavigate(object parameter) => !IsBusy;
        ...
        <Button Command="{Binding NavigateAsyncCommand}" 
                CommandParameter="{Binding StartText}"
                Text="{Binding StartText}"
                Grid.Row="1"/>
