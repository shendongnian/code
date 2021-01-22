    namespace Com.Examle.MyProject.Business {
        using Com.Example.MyProject.Shared;
        class Customer {
            // Reference obtained to an ICustomer implementation (not shown).
            // Composition of the data customer, just for illustration purposes
            ICustomer _cust;
            // From business, a data access usage example:
            public void GetData() {
                _cust.SaveToDataSource();
            }
        }
    }
