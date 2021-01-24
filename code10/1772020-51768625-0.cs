        public partial class Page2 : ContentPage
            {
             
                bool IsLoading{ get; set; }
                public Page2()
                {
                    InitializeComponent();
                      IsLoading = false;
              }
                 protected async override void OnAppearing()
        		{
                    base.OnAppearing();
                    if (!IsLoading)
                    {
                      IsLoading=true
                      **Call the Web API Method Here**
                    }
                    IsLoading=false
        		}
    
      
             }
          
