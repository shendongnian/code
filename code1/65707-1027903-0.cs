    using System;
    using System.Collections.Generic;
    
    namespace TestInstantiate838
    {
        public class Program
        {
            static void Main(string[] args)
            {
                List<ViewModelPageItemBase> pageItemViewModels = PageItemViewModels.GetAll();
    
                // No switch needed anymore. Each PageItem's view-model contains its PageItem
                // which is exposed as property of the view-model.
                foreach (ViewModelPageItemBase pageItemViewModel in pageItemViewModels)
                {
                    System.Console.WriteLine("{0}:{1}", pageItemViewModel.PageItem.IdCode, pageItemViewModel.PageItem.Title);
                }
                Console.ReadLine();
            }
        }
    
        public class PageItemManageCustomersViewModel : ViewModelPageItemBase
        {
            public PageItemManageCustomersViewModel()
            {
                PageItem = new PageItem { IdCode = "manageCustomers", Title = "ManageCustomers" };
            }
        }
    
        public class PageItemManageEmployeesViewModel : ViewModelPageItemBase
        {
            public PageItemManageEmployeesViewModel()
            {
                PageItem = new PageItem { IdCode = "manageEmployees", Title = "ManageEmployees" };
            }
        }
    
        public abstract class ViewModelPageItemBase : ViewModelBase
        {
            //The PageItem associated with this view-model
            public PageItem PageItem { get; protected set; }
        }
    
        public abstract class ViewModelBase
        {
            protected void OnPropertyChanged(string propertyName)
            {
                //this is the INotifyPropertyChanged method which all ViewModels need
            }
        }
    
        public class PageItem
        {
            public string IdCode { get; set; }
            public string Title { get; set; }
        }
    
        // Replaces PageItems class
        public class PageItemViewModels
        {
            // Return a list of PageItemViewModel's instead of PageItem's.
            // Each PageItemViewModel knows how to build it's corresponding PageItem object.
            public static List<PageItemViewModelBase> GetAll()
            {
                List<PageItemViewModelBase> pageItemViewModels = new List<PageItemViewModelBase>();
                pageItemViewModels.Add(new PageItemManageCustomersViewModel());
                pageItemViewModels.Add(new PageItemManageEmployeesViewModel());
                return pageItemViewModels;
            }
        }
    } 
