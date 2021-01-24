    namespace YourNamespace.ViewModels
    {
        public class ViewModelLocator
        {
            public ViewModelLocator()
            {                      
                Register<MainViewModel, MainPage>();            
            }
    
            public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();
            
            public void Register<VM, V>()
                where VM : class
            {
                SimpleIoc.Default.Register<VM>();
    
                NavigationService.Configure(typeof(VM).FullName, typeof(V));
            }
        }
    }
