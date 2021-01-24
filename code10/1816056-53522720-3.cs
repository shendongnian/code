    using Prism.Navigation;
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;
    
    namespace Project.ViewModels
    {
        public class ItemDetailViewModel : ViewModelBase
        {
            // ...
    
            public override void OnNavigatingTo(INavigationParameters parameters)
            {
                // Capture the parameter
                System.Diagnostics.Debug.WriteLine(parameters);
            }
    
            // ...
        }
    }
