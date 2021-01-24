          await Task.Run(() =>
            {
                Customers = new ObservableCollection<CustomerModel>(_customerRepository.Get());
            })
            .ContinueWith(t =>
            {
                Order.OrderCollection.CustomerID = (long)CustomerID;
                _eventAggregator.GetEvent<UIX_GlobalEvent.PassParameter>().Unsubscribe(ReloadCustomers);
            });
