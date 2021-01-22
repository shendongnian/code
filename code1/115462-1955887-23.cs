    namespace Com.Example.MyProject.Data {
        using Com.Example.MyProject.Shared; // for ICustomer
        class Customer : ICustomer { // implement ICustomer - other assemblies can too
            public void SaveToDataSource() {
                // logic to save data to the data source
            }
        }
    }
