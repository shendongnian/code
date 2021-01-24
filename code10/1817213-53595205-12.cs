    <?xml version="1.0" encoding="UTF-8"?>
    <views:MvxTabbedPage x:TypeArguments="viewModels:TabsRootViewModel"
        xmlns="http://xamarin.com/schemas/2014/forms" 
        xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
        xmlns:views="clr-namespace:MvvmCross.Forms.Views;assembly=MvvmCross.Forms"
        xmlns:mvx="clr-namespace:MvvmCross.Forms.Bindings;assembly=MvvmCross.Forms"
        xmlns:viewModels="clr-namespace:Playground.Core.ViewModels;assembly=Playground.Core"
        x:Class="Playground.Forms.UI.Pages.TabsRootPage" Title="TabsRoot page">
        <ContentPage.Content>
          
        </ContentPage.Content>
    </views:MvxTabbedPage>
    [MvxTabbedPagePresentation(TabbedPosition.Root, NoHistory = true)]
    public partial class TabsRootPage : MvxTabbedPage<TabsRootViewModel>
    {
        public TabsRootPage()
        {
            InitializeComponent();
        }
        private bool _firstTime = true;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_firstTime)
            {
                //ViewModel.ShowInitialViewModelsCommand.Execute();
                ViewModel.ShowInitialViewModelsCommand.ExecuteAsync(null);
                _firstTime = false;
            }
        }
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
        }
    }
