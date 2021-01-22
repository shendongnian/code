    using System;
    using System.Windows.Input;
    using Xamarin.Forms;
    
    namespace DataAndCloudServices
    {
        public partial class MainPage : ContentPage
    	{
    		public MainPage()
    		{
    			InitializeComponent();
    
                NavigateCommand = new Command<Type>(
                  async (Type pageType) =>
                  {
                      Page page = (Page)Activator.CreateInstance(pageType);
                      await Navigation.PushAsync(page);
                  });
    
                this.BindingContext = this;
            }
            public ICommand NavigateCommand { private set; get; }
        }
    }
