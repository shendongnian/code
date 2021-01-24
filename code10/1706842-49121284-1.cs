    private async void UpdateSelectedEmployeeAsync()
    {
        IsBusy = true;
        await QueryMyEmployeesAddressesAndOtherDataAsync();
        IsBusy = false;
    }
    private async Task QueryMyEmployeesAddressesAndOtherDataAsync()
    {
        using (var ctx = new MyContext())
        {
            var queryResults = await ctx.EmployeeData.Where(t=>t.EmployeeId == SelectedEmployee.Id).ToArrayAsync();
            SelectedEmployeeDatas.Clear();
            foreach (var data in queryResults)
            {
                SelectedEmployeeDatas.Add(data);
            }
        }
    }
