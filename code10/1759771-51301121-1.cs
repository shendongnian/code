    protected override async void OnBindingContextChanged()
            {
                base.OnBindingContextChanged();
                if (BindingContext is MyPageViewModel viewModel)
                {
                            foreach (var i in wasteDescription)
                 {
                if (i.description_Id == wasteObject.Waste_Id)
                     {
                         await viewModel.getDescription(i.wasteImage, i.sortName, i.wasteDescription, myWebView, (error) => 
                         {
                             if(error != null)
                             {
                                 DisplayAlert("Problem", "Not possible", "Ok");
                             }
                         });
                     }
                }
