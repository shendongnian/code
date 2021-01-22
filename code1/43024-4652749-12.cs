    using System.Collections.Generic;
    using System.Windows;
    
    namespace TestDatagrid345
    {
      public partial class Window1 : Window
      {
        Window1ViewModel _viewModel;
        public Window1()
        {
          InitializeComponent();
          _viewModel = (Window1ViewModel)this.DataContext; // @#$% (see XAML)
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          // but this stuff could instead be done on a 'Submit' button click on form:
          _viewModel.Customers.Add(new Customer { FirstName = "Tom", LastName = "Jones" });
          _viewModel.Customers.Add(new Customer { FirstName = "Joe", LastName = "Thompson" });
          _viewModel.Customers.Add(new Customer { FirstName = "Jill", LastName = "Smith" });
        }
      }
    }
