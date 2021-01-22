    using System.Collections.Generic;
    namespace TestDatagrid345.ViewModels
    {
      class Window1ViewModel
      {
        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();
        public ObservableCollection<Customer> Customers
        {
          Get { return _customers; }
        }
      }
    }
