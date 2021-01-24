    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    namespace MVVMListAndDetailExample.Views
    {
        // Learn more about making custom code visible in the Xamarin.Forms previewer
        // by visiting https://aka.ms/xamarinforms-previewer
        [DesignTimeVisible(false)]
        public partial class MainPage : ContentPage
        {
            public MainPage()
            {
                InitializeComponent();
                BindingContext = new ViewModels.MainPageViewModel();
            }
            async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
            {
                await Navigation.PushModalAsync(new Views.PersonDetailPage(e.Item as ViewModels.PersonViewModel));
            }
        }
    }
