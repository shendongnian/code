    using System;
    using System.Collections.Generic;
    using Xamarin.Forms;
    namespace MVVMListAndDetailExample.Views
    {
        public partial class PersonDetailPage : ContentPage
        {
            public PersonDetailPage(ViewModels.PersonViewModel personViewModel)
            {
                InitializeComponent();
                BindingContext = personViewModel;
            }
            async void Handle_Clicked(object sender, System.EventArgs e)
            {
                await Navigation.PopModalAsync();
            }
        }
    }
