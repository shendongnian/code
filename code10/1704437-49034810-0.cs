    private async void ExternalConnectionStringVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "ConnectionString")
        {
            if (this.ExternalConnectionStringVM.CanConnect)
            {
                Services.SqlServerDatabaseInfoService service = new Services.SqlServerDatabaseInfoService();
                //copy the string into a variable
                string connectionStringBefore = this.ExternalConnectionStringVM.ConnectionStringModel.ConnectionString;
                //call the method
                var sps = await service.GetAllStoreProceduresAsync(connectionString);
                //compare the string with the current property 
                if (this.ExternalConnectionStringVM.ConnectionStringModel.ConnectionString == connectionStringBefore)
                {
                    this.ExternalStoreProcedures.Clear();
                    foreach (string sp in sps.Result)
                    {
                        this.ExternalStoreProcedures.Add(sp);
                    }
                }
            }
        }
    }
