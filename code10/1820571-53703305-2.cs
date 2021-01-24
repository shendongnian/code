     private Project_View_ViewModel bindingv;
        public Project_View()
        {
            try
            {
                InitializeComponent();
                bindingv = new Project_View_ViewModel(Navigation);
                BindingContext = bindingv;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                if (bindingv != null)
                {
                    await bindingv.GetProjects();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
        }
