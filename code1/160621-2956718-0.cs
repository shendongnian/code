            public ObservableCollection<AddressViewModel> Addresses { get; set; }
        public RelayCommand AddAddressCommand
        {
            get
            {
                if (_addAddressCommand == null)
                {
                    _addAddressCommand = new RelayCommand(p => this.AddAddress_Execute());
                }
                return _addAddressCommand;
            }
        }
        private void AddAddress_Execute()
        {
            Addresses.Add(new AddressViewModel());
        }
