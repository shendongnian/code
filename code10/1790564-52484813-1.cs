    using System.Windows;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    namespace RaisePropertyChangedExample
    {
       public partial class BindingExample : Window
       {
          public BindingExample()
          {
             InitializeComponent();
             DataContext = new BindingExampleViewModel();
          }
       }
    
       public class BindingExampleViewModel
       {
          public ObservableCollection<TestItemViewModel> Items { get; set; }
             = new ObservableCollection<TestItemViewModel>(new List<TestItemViewModel>
             {
                new TestItemViewModel {Name = "Test1"},
                new TestItemViewModel {Name = "Test2"}
             });
       }
    
       public class TestItemViewModel
       {
          public string Name { get; set; }
       }
    }
