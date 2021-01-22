    using System.Collections.Generic;
    
    namespace TestInstantiate838
    {
        public class Program
        {
            static void Main(string[] args)
            {
                List<PageItem> pageItems = PageItems.GetAll();
                List<ViewModelBase> pageItemViewModels = new List<ViewModelBase>();
    
                foreach (PageItem pageItem in pageItems)
                {
                    switch (pageItem.IdCode)
                    {
                        case "manageCustomers":
                            pageItemViewModels.Add(new PageItemManageCustomersViewModel(pageItem));
                            break;
                        case "manageEmployees":
                            pageItemViewModels.Add(new PageItemManageEmployeesViewModel(pageItem));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    
        public class PageItemManageCustomersViewModel : PageViewModelBase
        {
            public PageItemManageCustomersViewModel(PageItem pageItem)
            {
    
            }
        }
    
        public class PageItemManageEmployeesViewModel : PageViewModelBase
        {
            public PageItemManageEmployeesViewModel(PageItem pageItem)
            {
    
    
            }
        }
    
        public abstract class ViewModelBase
        {
            protected void OnPropertyChanged(string propertyName)
            {
                //this is the INotifyPropertyChanged method which all ViewModels need
            }
        }
    
        public abstract class PageViewModelBase : ViewModelBase
        {
            //these are the properties which every PageItemViewModel needs
            public string IdCode { get; set; }
            public string Title { get; set; }
        }
    
        public class PageItem
        {
            public string IdCode { get; set; }
            public string Title { get; set; }
        }
    
        public class PageItems
        {
            public static List<PageItem> GetAll()
            {
                List<PageItem> pageItems = new List<PageItem>();
                pageItems.Add(new PageItem { IdCode = "manageCustomers", Title = "ManageCustomers"});
                pageItems.Add(new PageItem { IdCode = "manageEmployees", Title = "ManageEmployees"});
                return pageItems;
            }
        }
    
    }
