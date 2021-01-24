    public class RegisterViewModel : BindableBase
    {
        private RegisterBindingModel _registerBindingModel;
        public RegisterBindingModel RegisterBindingModel 
        {
            get
            {
                return this._registerBindingModel;
            }
            set{
                SetProperty(ref this._registerBindingModel, value);
            }
        }
        public RegisterViewModel(INavigationService navigationService)
        {
            //...
            this.RegisterBindingModel = new RegisterBindingModel();
        }
    }
