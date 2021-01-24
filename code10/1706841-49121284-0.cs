    public Employee SelectedEmployee
    {
        get
        {
            return mvSelectedEmployee;
        }
        set
        {
            mvSelectedEmployee = value;
            RaisePropertyChanged();
            UpdateSelectedEmployeeAsync();
        }
    }
    private async void UpdateSelectedEmployeeAsync()
    {
        IsBusy = true;
        await Task.Run(() => QueryMyEmployeesAddressesAndOtherData());
        IsBusy = false;
    }
