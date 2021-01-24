    using Prism;
    using Prism.Mvvm;
    using Prism.Navigation;
    using System;
    
    namespace Project.ViewModels
    {
        // INavigationAware provides a way for objects involved in navigation to be notified of navigation activities.
        public class ViewModelBase : BindableBase, INavigationAware, IDestructible
        {
            // ...
    
            protected INavigationService NavigationService { get; private set; }
    
            public ViewModelBase(INavigationService navigationService) => NavigationService = navigationService;
    
            /// <summary>
            /// Called when the implementer is being navigated away from.
            /// </summary>
            public virtual void OnNavigatedFrom(INavigationParameters parameters)
            {
    
            }
    
            /// <summary>
            /// Called when the implementer has been navigated to.
            /// </summary>
            public virtual void OnNavigatedTo(INavigationParameters parameters)
            {
    
            }
    
            // ...
        }
    }
