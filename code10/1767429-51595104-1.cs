    public abstract class ViewBase : ContentPage
    {
        protected ViewModelBase viewModel;
        internal ViewModelBase ViewModel
        {
            get
            {
                return this.viewModel;
            }
            set
            {
                if (this.viewModel != value)
                {
                    this.viewModel = value;
                    // Make sure we bind the view model to the UI.
                    this.BindingContext = value;
                }
            }
        }
    }
