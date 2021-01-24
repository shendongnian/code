      WaitViewModel WaitViewModel;
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                // get data context 
                 WaitViewModel = this.DataContext as WaitViewModel;
                WaitViewModel.PropertyChanged += WaitViewModel_PropertyChanged;
            }
    
            private void WaitViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                if(e.PropertyName == "CloseRequest")
                {
                    Dispatcher dispatcher = this.Dispatcher;
                    if (WaitViewModel.CloseRequest)
                        dispatcher.Invoke(() => { 
                        this.Close();
                        });
                }
            }
