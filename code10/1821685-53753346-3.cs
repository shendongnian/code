    public partial class ProviderPage : ContentPage
        {
            public ProviderPage()
            {
                InitializeComponent();            
    			theFrame.IsVisible = true; // Show the Frame on top of tabView
                ProductsTabView.Items = GetTabItemCollection();    
    			theFrame.IsVisible = false; // Hide the Frame
            }
            ...
