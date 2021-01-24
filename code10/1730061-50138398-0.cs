    /// <summary>
    /// My view model class
    /// </summary>
    public class MyVM : INotifyPropertyChanged
    {
        // VM logic
        // ...
        // events
        private event EventHandler<string> OnRequestShowDialog;
        // calling event
        public void BusinessMethod()
        {
            // ...
            OnRequestShowDialog?.Invoke(this, "Business method completed successfully...");
        }}
    
    /// <summary>
    /// My page class
    /// </summary>
    public class MyPage : ContentPage
    {
        public MyPage()
        {
            // New VM 
            BindingContextChanged += (sender, args) =>
            {
                // Connect to your VM's events here
                (this.BindingContext as MyVM).OnRequestShowDialog += (e, message) => {
                this.DisplayAlert("info", args, "ok");
            };
        };
    }
    }
