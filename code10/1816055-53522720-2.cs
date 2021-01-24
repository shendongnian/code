    using Prism.Navigation;
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;
    
    namespace Project.ViewModels
    {
        public class ItemViewModel : ViewModelBase
        {
            // ...
    
            private ObservableCollection<ItemList> _items;
            public ObservableCollection<ItemList> Items
            {
                get => _items;
                set => SetProperty(ref _items, value);
            }
    
            public ICommand ItemTappedCommand => new AsyncCommand(ItemTappedCommandAsync);
    
            public ItemViewModel(INavigationService navigationService)
                : base(navigationService)
            {
                Items = new ObservableCollection<ItemList>();
                // Load the data
            }
    
            // ...
    
            private async Task ItemTappedCommandAsync(object item)
            {
                var navParams = new NavigationParameters
                {
                    { "ItemSelected", (Item)item }
                };
    
                await NavigationService.NavigateAsync(nameof(ItemDetailView), navParams);
            }
        }
    }
